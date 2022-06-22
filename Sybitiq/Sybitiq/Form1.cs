namespace Sybitiq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Connection connection = new Connection();

        private void button1_Click(object sender, EventArgs e)
        {
            List<sybitiq> aktiviList = new List<sybitiq>();
            var p = new Connection();
            p.pomalkaot30(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<sybitiq> aktiviList = new List<sybitiq>();
            var p = new Connection();
            p.pogolqmaot30(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            sybitiq p = new sybitiq();
            p.sybitie = textBox2.Text;
            p.grad = textBox3.Text;
            p.tema = textBox4.Text;
            p.data = DateTime.Parse(dateTimePicker1.Text);
            p.nachalenChas = Int32.Parse(textBox5.Text);
            p.kraenChas = Int32.Parse(textBox6.Text);
            p.mqsto = Int32.Parse(textBox7.Text);
            p.cena = Int32.Parse(textBox8.Text);

            connection.Insert(p);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            sybitiq p = new sybitiq();
            p.ID = int.Parse(textBox1.Text);
            p.sybitie = textBox2.Text;
            p.grad = textBox3.Text;
            p.tema = textBox4.Text;
            p.data = DateTime.Parse(dateTimePicker1.Text);
            p.nachalenChas = Int32.Parse(textBox5.Text);
            p.kraenChas = Int32.Parse(textBox6.Text);
            p.mqsto = Int32.Parse(textBox7.Text);
            p.cena = Int32.Parse(textBox8.Text);

            connection.Update(p);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sybitiq p = new sybitiq();
            p.ID = Int32.Parse(textBox1.Text);
            connection.Delete(p);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<sybitiq> aktiviList = new List<sybitiq>();
            var p = new Connection();
            p.sortirovkaime(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<sybitiq> aktiviList = new List<sybitiq>();
            var p = new Connection();
            p.sortirovkagrad(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<sybitiq> aktiviList = new List<sybitiq>();
            var p = new Connection();
            p.sortirovkanachalenchas(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            List<sybitiq> aktiviList = new List<sybitiq>();
            var p = new Connection();
            p.sortirovkanakraenchas(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<mqsto> aktiviList = new List<mqsto>();
            var p = new Connection();
            p.sortirovkamqsto(aktiviList);

            var source = new BindingSource();
            source.DataSource = aktiviList;
            dataGridView1.DataSource = source;
        }
    }
}