using AutoMapper;
using Biosite.Core.Commands;
using Biosite.Core.Model;
using Biosite.Domain.Commands.Request.Biomarker;
using Biosite.Domain.Commands.Response;
using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Transactions;
using FluentValidator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biosite.Biomarkers.Api.Application.Commands.Handlers
{
    public class BiomarkerCommandHandler : Notifiable,
                                            ICommandHandler<RegisterBiomarkerRequest>,
                                            ICommandHandler<UpdateBiomarkerRequest>,
                                            ICommandHandler<DeleteBiomarkerRequest>
    {
        private readonly IBiomarkerRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public BiomarkerCommandHandler(IBiomarkerRepository repository, IMapper mapper, IUow uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        #region GET VERBS

        public async Task<IEnumerable<BiomarkerResponse>> Handle()
        {
            var commandObject = await _repository.GetAllAsync();

            return _mapper.Map<List<BiomarkerResponse>>(commandObject);
        }

        public async Task<BiomarkerResponse> Handle(SelectBiomarkerByIdRequest command)
        {
            var commandObject = await _repository.GetByIdAsync(command.Id);

            if (commandObject == null)
            {
                var objectNotification = new Message();
                objectNotification.AddNotification(new Notification("Biomarcador", "Biomarcador não encontrado"));
                AddNotifications(objectNotification.Notifications);
                return null;
            }

            return _mapper.Map<BiomarkerResponse>(commandObject);
        }

        public async Task<BiomarkerResponse> Handle(SelectBiomarkerByNameRequest command)
        {
            var commandObject = await _repository.GetByNameAsync(command.Name);

            return _mapper.Map<BiomarkerResponse>(commandObject);
        }

        #endregion

        #region POST, UPDATE AND DELETE VERBS

        public async Task<ICommandResult> Handle(RegisterBiomarkerRequest command)
        {
            // 1. Criar instância do objeto
            var commandObject = new Biomarker(default, command.Name, command.Description, command.Unity, command.BodyImageType, command.OptimizedValuesMin, command.OptimizedValuesMax, 
                command.AboveImpact, command.BelowImpact);

            // 2. Adicionar notificações
            AddNotifications(commandObject.Notifications);

            // 3. Verificar se é válido (se existem notificações
            if (!IsValid())
                return null;

            // 4. Salva as alterações no EF
            await _repository.AddAsync(commandObject);
            await _uow.Commit();

            // 5. Retorna os dados que foram cadastrados
            return new BiomarkerResponse(commandObject.Id, commandObject.Name, commandObject.Description, commandObject.Unity, commandObject.BodyImageType, commandObject.AboveImpact, commandObject.BelowImpact);
        }

        public async Task<ICommandResult> Handle(UpdateBiomarkerRequest command)
        {
            // 1. Criar instância do objeto
            var commandObject = new Biomarker(command.Id, command.Name, command.Description, command.Unity, command.BodyImageType, command.OptimizedValuesMin, command.OptimizedValuesMax,
                command.AboveImpact, command.BelowImpact);

            // 2. Adicionar notificações
            AddNotifications(commandObject.Notifications);

            // 3. Verificar se é válido (se existem notificações
            if (!IsValid())
                return null;

            // 4. Salva as alterações no EF
            _repository.Update(commandObject);
            await _uow.Commit();

            // 5. Retorna os dados que foram cadastrados
            return new BiomarkerResponse(commandObject.Id, commandObject.Name, commandObject.Description, commandObject.Unity, commandObject.BodyImageType, commandObject.AboveImpact, commandObject.BelowImpact);

        }

        public async Task<ICommandResult> Handle(DeleteBiomarkerRequest command)
        {
            var commandObject = await _repository.GetByIdAsync(command.Id);

            if (commandObject == null)
            {
                var objectNotification = new Message();
                objectNotification.AddNotification(new Notification("Biomarcador", "Biomarcador não encontrada"));
                AddNotifications(objectNotification.Notifications);
                return null;
            }

            // 4. Deleta o registro
            _repository.Delete(commandObject);
            await _uow.Commit();

            // 5. Retorna os dados deletados
            return new BiomarkerResponse(commandObject.Id, commandObject.Name, commandObject.Description, commandObject.Unity, commandObject.BodyImageType, commandObject.AboveImpact, commandObject.BelowImpact);
        }

        #endregion
    }
}
