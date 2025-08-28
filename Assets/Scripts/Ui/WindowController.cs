namespace Ui
{
    public abstract class WindowController<TView> : IWindowController where TView : WindowView
    {
        protected TView View { get; private set; }

        protected WindowController(TView view)
        {
            View = view;
        }
        
        public void Activate()
        {
            OnShow();
        }

        public void Deactivate()
        {
            OnHide();
        }
        
        protected virtual void OnShow() { }
        protected virtual void OnHide() { }
    }
}