using System;
using System.Windows.Forms;
using FractalPainting.App.Actions;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Conventions;

namespace FractalPainting.App
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                var container = new StandardKernel();
                container.Bind<IImageHolder, PictureBoxImageHolder>().To<PictureBoxImageHolder>().InSingletonScope();

                container.Bind(x =>
                    x.FromThisAssembly().SelectAllClasses().InNamespaceOf<SaveImageAction>().BindAllInterfaces());

                
                /*container.Bind<IUiAction>().To<SaveImageAction>();
                container.Bind<IUiAction>().To<DragonFractalAction>();
                container.Bind<IUiAction>().To<PaletteSettingsAction>();
                container.Bind<IUiAction>().To<KochFractalAction>();
                container.Bind<IUiAction>().To<ImageSettingsAction>();*/

                container.Bind<KochPainter>().To<KochPainter>();
                container.Bind<Palette>().ToSelf().InSingletonScope();
                container.Bind<IDragonPainterFactory>().ToFactory();
                container.Bind<IObjectSerializer>().To<XmlObjectSerializer>();
                container.Bind<IBlobStorage>().To<FileBlobStorage>();
                container.Bind<IImageDirectoryProvider>().To<AppSettings>();
                container.Bind<ImageSettings>().ToMethod(context => context.Kernel.Get<SettingsManager>().Load().ImageSettings);


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(container.Get<MainForm>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
    }
}