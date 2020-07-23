using System;
using FastCli.Sample.ViewInterfaces;

namespace FastCli.Sample.Controllers
{
    public class InfoController
    {
        private IInfoCommand _view;

        public void Run()
        {
            _view.Message = $"Hello {_view.Title}";
        }

        public void RegisterView(IInfoCommand view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }
    }
}
