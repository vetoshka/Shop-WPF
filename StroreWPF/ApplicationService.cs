using Prism.Events;

namespace StoreWPF
{
    public class ApplicationService:IEventAggregator
    {
        private ApplicationService() { }

        internal static ApplicationService Instance { get; } = new ApplicationService();

        private IEventAggregator _eventAggregator;
        internal IEventAggregator EventAggregator {
            get { return _eventAggregator ??= new EventAggregator(); }
        }

        public TEventType GetEvent<TEventType>() where TEventType : EventBase, new()
        {
            throw new System.NotImplementedException();
        }
    }
}
