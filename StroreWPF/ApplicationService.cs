using Prism.Events;

namespace StoreWPF
{
    internal class ApplicationService
    {
        private ApplicationService() { }

        private static readonly ApplicationService _instance = new ApplicationService();

        internal static ApplicationService Instance => _instance;

        private IEventAggregator _eventAggregator;
        internal IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null)
                {
                    _eventAggregator = new EventAggregator();
                }

                return _eventAggregator;
            }
        }
    }
}
