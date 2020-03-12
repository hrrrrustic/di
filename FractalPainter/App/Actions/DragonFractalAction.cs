using System;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;

namespace FractalPainting.App.Actions
{
    public class DragonFractalAction : IUiAction
    {
        private IDragonPainterFactory factory;
        private Func<DragonSettingsGenerator> settingsFactory;
        public DragonFractalAction(IDragonPainterFactory factory, Func<DragonSettingsGenerator> settingsFactory)
        {
            this.factory = factory;
            this.settingsFactory = settingsFactory;
        }

        public Category Category { get; } = Category.Fractals;
        public string Name => "Дракон";
        public string Description => "Дракон Хартера-Хейтуэя";

        public void Perform()
        {
            var dragonSettings = settingsFactory().Generate();
            SettingsForm.For(dragonSettings).ShowDialog();
            factory.CreateDragonPainter(dragonSettings).Paint();
        }

        private static DragonSettings CreateRandomSettings()
        {
            return new DragonSettingsGenerator(new Random()).Generate();
        }
    }
}