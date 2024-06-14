using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit> //Unit is Somewhat void in MediatR
    { 
    }
    public interface ICommand<out Tresponse> : IRequest<Tresponse>
    {
    }
}
