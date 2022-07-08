namespace Biosite.Core.Commands.Response
{
    public class PlanAreaResponse : ICommandResult
    {
        public PlanAreaResponse()
        {

        }

        //public PlanResponse Plan { get; set; }

        public AreaResponse Area { get; set; }
    }
}
