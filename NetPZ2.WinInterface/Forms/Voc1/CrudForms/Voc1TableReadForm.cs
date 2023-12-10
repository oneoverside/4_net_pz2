using Uni_NET_PZ2.DbSource;

namespace Uni_NET_PZ2.Forms.Voc1.CrudForms;

public partial class Voc1TableReadForm : Form
{
    private readonly DataGridView _dataGridView;
    
    public Voc1TableReadForm()
    {
        this.InitializeComponent();
        this.Load += this.GetMainTableElements;

        this._dataGridView = new DataGridView();
        this._dataGridView.Dock = DockStyle.Fill; 
        
        this.Controls.Add(this._dataGridView);
    }

    private void GetMainTableElements(object? sender, EventArgs e)
    {
        var context = new MyDbContext();
        context.InitializeDatabase();
        this._dataGridView.DataSource = context.ReadAllFromVoc1Table();
    }
}