namespace Uni_NET_PZ2.Forms.MainTable.CrudForms;

public partial class MainTableReadForm : Form
{
    private readonly DataGridView _dataGridView;
    
    public MainTableReadForm()
    {
        this.InitializeComponent();
        this.Load += this.GetMainTableElements;

        this._dataGridView = new DataGridView();
        this._dataGridView.Dock = DockStyle.Fill; 
        this.Controls.Add(this._dataGridView); 
        
        this.Controls.Add(this._dataGridView);
    }

    private void GetMainTableElements(object? sender, EventArgs e)
    {
        var elements = new List<string> { "Hello", "World"};
        this._dataGridView.DataSource = elements;
    }
}