using lab2.File;
using lab2.Shapes;

namespace lab2
{
    public partial class Form1 : Form
    {
        private List<IShape> _shapes;

        private readonly string _textInFileDialog = "Text Files|*.txt";
        private readonly string _warningNoShapes = "No shapes loaded. Load shapes first.";
        private readonly string _captionWarning = "Warning";

        public Form1()
        {
            InitializeComponent();
            btnLoad.Click += BtnLoadClick;
        }

        private void BtnLoadClick(object sender, EventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = _textInFileDialog
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                FileProcessor fileProcessor = new();
                _shapes = fileProcessor.ReadShapes(filePath);

                fileProcessor.WriteResults(_shapes);
            }

            if (_shapes != null)
            {
                using Graphics graphics = CreateGraphics();

                graphics.Clear(Color.White);

                foreach (IShape shape in _shapes)
                {
                    shape.Draw(graphics);
                }
            }
            else MessageBox.Show(_warningNoShapes, _captionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}