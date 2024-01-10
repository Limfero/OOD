using lab1.File;
using lab1.Shapes;

namespace lab1
{
    public partial class Form1 : Form
    {
        private List<IShape> shapes;

        private readonly string _textInFileDialog = "Text Files|*.txt";
        private readonly string _warningNoShapes = "No shapes loaded. Load shapes first.";
        private readonly string _captionWarning = "Warning";

        public Form1()
        {
            InitializeComponent();
            btnLoad.Click += BtnLoadClick;
            btnSave.Click += BtnSaveClick;
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
                shapes = fileProcessor.ReadShapes(filePath);
            }

            if (shapes != null)
            {
                using Graphics graphics = CreateGraphics();

                graphics.Clear(Color.White);

                foreach (IShape shape in shapes)
                {
                    shape.Draw(graphics);
                }
            }
            else MessageBox.Show(_warningNoShapes, _captionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnSaveClick(object sender, EventArgs eventArgs)
        {
            if (shapes != null)
            {
                SaveFileDialog saveFileDialog = new()
                {
                    Filter = _textInFileDialog
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    FileProcessor fileProcessor = new();
                    fileProcessor.WriteResults(filePath, shapes);
                }
            }
            else MessageBox.Show(_warningNoShapes, _captionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}