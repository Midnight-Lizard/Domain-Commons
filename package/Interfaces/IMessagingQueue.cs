using System.Threading;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Interfaces
{
    public interface IMessagingQueue
    {
        bool CheckStatus();
        Task BeginProcessing(CancellationToken token);
        Task ResumeProcessing(CancellationToken token);
        Task PauseProcessing();
    }
}