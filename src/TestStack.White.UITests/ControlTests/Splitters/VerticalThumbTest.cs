using System.Collections.Generic;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;

namespace TestStack.White.UITests.ControlTests.Splitters
{
    public class VerticalThumbTest : WhiteTestBase
    {
        protected override void RunTest(WindowsFramework framework)
        {
            var window = OpenVerticalSliderWindow();
            using (new DelegateDisposable(() => CloseSliderWindow(window)))
            {
                RunTest(() => Find(window));
                RunTest(() => Slide(window));
            }
        }

        public void Find(Window window)
        {
            var thumb = window.Get<Thumb>("Splitter");
            Assert.AreNotEqual(null, thumb);
        }

        public void Slide(Window window)
        {
            var thumb = window.Get<Thumb>("Splitter");
            var originalY = thumb.Location.Y;
            thumb.SlideVertically(50);
            Assert.AreEqual(originalY + 50, thumb.Location.Y);
        }

        private void CloseSliderWindow(Window window)
        {
            window.Close();
        }

        private Window OpenVerticalSliderWindow()
        {
            MainWindow.Get<Button>("OpenVerticalSplitterButton").Click();
            var openVerticalSliderWindow = MainWindow.ModalWindow("VerticalGridSplitter");
            return openVerticalSliderWindow;
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            // yield return FrameworkId.Silverlight; Has some timing issues
        }
    }
}