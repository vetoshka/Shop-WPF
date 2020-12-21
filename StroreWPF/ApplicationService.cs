using Prism.Events;

namespace StoreWPF
{
    public class ApplicationService
    {
        private ApplicationService() { }

        internal static ApplicationService Instance { get; } = new ApplicationService();

        private IEventAggregator _eventAggregator;
        internal IEventAggregator EventAggregator {
            get { return _eventAggregator ??= new EventAggregator(); }
        }
    }
}
