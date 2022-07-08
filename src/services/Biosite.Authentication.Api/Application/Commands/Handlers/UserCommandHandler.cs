using AutoMapper;
using Biosite.Core.Commands;
using Biosite.Core.Commands.Response;
using Biosite.Core.Library;
using Biosite.Core.Model;
using Biosite.Domain.Commands.Request.User;
using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Transactions;
using FluentValidator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biosite.Authentication.Api.Application.Commands.Handlers
{
    public class UserCommandHandler : Notifiable,
                                            ICommandHandler<RegisterUserRequest>,
                                            ICommandHandler<UpdateUserRequest>,
                                            ICommandHandler<DeleteUserRequest>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public UserCommandHandler(IUserRepository repository, IMapper mapper, IUow uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        #region GET VERBS

        public async Task<IEnumerable<UserResponse>> Handle(int? skip = null, int? take = null)
        {
            var commandObject = await _repository.GetAllAsync(skip, take);

            return _mapper.Map<List<UserResponse>>(commandObject);
        }

        public async Task<UserResponse> Handle(string email, string password)
        {
            var commandObject = await _repository.LoginUserAsync(email, SharedFunctions.EncryptPassword(password));

            if (commandObject == null)
            {
                var objectNotification = new Message();
                objectNotification.AddNotification(new Notification("Login", "Usuário ou senha inválidos"));
                AddNotifications(objectNotification.Notifications);
                return null;
            }

            if (!commandObject.Active || !commandObject.Verified)
            {
                var objectNotification = new Message();
                objectNotification.AddNotification(new Notification("User", "Este e-mail não está ativo, é necessário ativar seu e-mail para logar no sistema."));
                AddNotifications(objectNotification.Notifications);
                return null;
            }

            var result = _mapper.Map<UserResponse>(commandObject);
            UpdateLoginDate(commandObject);
            await _uow.Commit();
            return result;
        }

        #endregion

        #region POST, UPDATE AND DELETE VERBS

        public async Task<ICommandResult> Handle(RegisterUserRequest command)
        {
            // 1. Criar instância do objeto
            var commandObject = new User(default, command.Username, command.Password, command.ConfirmPassword, command.Email, command.Weight, command.Height, command.Gender, command.Birthdate, command.PlanId, command.Pregnant);

            // 2. Adicionar notificações
            AddNotifications(commandObject.Notifications);

            // 3. Verificar se é válido (se existem notificações
            if (!IsValid())
                return null;

            // 4. Salva as alterações no EF
            await _repository.AddAsync(commandObject);
            await _uow.Commit();

            // 5. Retorna os dados que foram cadastrados
            return new UserResponse(commandObject.Id, commandObject.Name, commandObject.Email, commandObject.Weight, commandObject.Height, commandObject.Gender, commandObject.Birthdate, commandObject.LastLoginDate);

        }

        public async Task<ICommandResult> Handle(UpdateUserRequest command)
        {
            // 1. Criar instância do objeto
            var commandObject = new User(default, command.Username, command.Password, command.ConfirmPassword, command.Email, command.Weight, command.Height, command.Gender, command.Birthdate, command.PlanId, command.Pregnant);

            // 2. Adicionar notificações
            AddNotifications(commandObject.Notifications);

            // 3. Verificar se é válido (se existem notificações
            if (!IsValid())
                return null;

            // 4. Salva as alterações no EF
            _repository.Update(commandObject);
            await _uow.Commit();

            // 5. Retorna os dados que foram cadastrados
            return new UserResponse(commandObject.Id, commandObject.Name, commandObject.Email, commandObject.Weight, commandObject.Height, commandObject.Gender, commandObject.Birthdate, commandObject.LastLoginDate);

        }

        public async Task<ICommandResult> Handle(DeleteUserRequest command)
        {
            var commandObject = await _repository.GetByIdAsync(command.Id);

            if (commandObject == null)
            {
                var objectNotification = new Message();
                objectNotification.AddNotification(new Notification("Usuário", "Email não encontrado"));
                AddNotifications(objectNotification.Notifications);
                return null;
            }

            // 4. Deleta o registro
            _repository.Delete(commandObject);
            await _uow.Commit();

            // 5. Retorna os dados deletados
            return new UserResponse(commandObject.Id, commandObject.Name, commandObject.Email, commandObject.Weight, commandObject.Height, commandObject.Gender, commandObject.Birthdate, commandObject.LastLoginDate);

        }

        #endregion

        private void UpdateLoginDate(User user)
        {
            user.UpdateLoginInfo();
            _repository.Update(user);
        }

    }
}
