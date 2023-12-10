using Uni_NET_PZ2.DbSource;

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
    }

    private void GetMainTableElements(object? sender, EventArgs e)
    {
        this._dataGridView.DataSource = new MyDbContext().ReadAllFromMainTable();
    }
}