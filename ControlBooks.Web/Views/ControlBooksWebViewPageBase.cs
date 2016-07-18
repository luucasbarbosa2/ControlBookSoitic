using Abp.Web.Mvc.Views;

namespace ControlBooks.Web.Views
{
    public abstract class ControlBooksWebViewPageBase : ControlBooksWebViewPageBase<dynamic>
    {

    }

    public abstract class ControlBooksWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ControlBooksWebViewPageBase()
        {
            LocalizationSourceName = ControlBooksConsts.LocalizationSourceName;
        }
    }
}