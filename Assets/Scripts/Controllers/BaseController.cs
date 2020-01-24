using UnityEngine;

namespace Shooter
{
    public abstract class BaseController
    {
        protected Inventory Inventory = new Inventory();
        protected UIInterface UIInterface = new UIInterface();
        protected bool IsActive;

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(BaseObjectModel obj)
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public virtual void Switch()
        {
            if (IsActive)
            {
                Off();
            }
            else
            {
                On();
            }
        }
    }
}
