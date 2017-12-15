using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagCloud.Core.Drawing;
using TagCloud.Core.Layouters;
using TagCloud.Core.Layouters.Contract;
using TagCloud.Core.Words;
using TagCloud.Core.Words.Contract;
using TagCloud.Core.Words.Filtering;
using TagCloud.Core.Words.Loaders;
using TagCloud.Core.Words.PreProcessing;
using TagCloud.Core.Words.Statistics;

namespace TagCloud.Client.Forms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IWordProcessor[] processors = {
                new WordFilter(w => w.Length > 5), 
                new ToLowerProcessor(),
                new CleanUpWords(),
            };

            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<PlainTextLoader>().As<IWordsLoader>();
            containerBuilder.RegisterType<WordStatisticFactory>().WithParameter("processor", new WordProcessorChain(processors));
            containerBuilder.Register(c => c.Resolve<WordStatisticFactory>().CreateFromFile("test.txt")).As<IWordsStatistic>();

            containerBuilder.RegisterType<FontFactory>().As<IFontFactory>();
            containerBuilder.RegisterType<Colorizer>().As<IColorizer>();
            containerBuilder.RegisterType<TextMeasurer>().As<ITextMeasurer>();
            containerBuilder.RegisterType<TagsViewFactory>().AsSelf();

            containerBuilder.RegisterType<TagsViewRenderer>().AsSelf();

            containerBuilder.RegisterType<CircularCloudLayouter>().As<IRectangleLayouter>()
                .WithParameter("placementCircleRadius", 300).WithParameter("placementCircleSegments", 32)
                .WithParameter("accuracy", 0.1);

            containerBuilder.RegisterType<WordsCloudRenderer>().AsSelf();

            containerBuilder.RegisterType<Form1>().AsSelf().WithParameter("maxWords", 50);

            var container = containerBuilder.Build();

            Application.Run(container.Resolve<Form1>());
        }
    }
}
