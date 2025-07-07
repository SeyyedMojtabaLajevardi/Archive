using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Archive.BusinessLogic
{
    public class CustomAutoCompleteSuggestHelper : AutoCompleteSuggestHelper
    {
        public CustomAutoCompleteSuggestHelper(RadDropDownListElement owner)
            : base(owner)
        {
        }

        protected override bool DefaultFilter(RadListDataItem item)
        {
            if (item != null)
            {
                bool matchesFilter = item.Text.ToLower().Contains(this.Filter.ToLower());
                return matchesFilter;
            }
            return base.DefaultFilter(item);
        }
    }
}
