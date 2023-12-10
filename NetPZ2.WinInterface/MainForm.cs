using Uni_NET_PZ2.Forms.MainTable;
using Uni_NET_PZ2.Forms.Voc1;

namespace Uni_NET_PZ2;

public partial class MainForm : Form
{
    public MainForm()
    {
        this.InitializeComponent();

        var mainTableManagerButton = new Button();
        mainTableManagerButton.Location = new Point(50, 150); // Позиция на форме
        mainTableManagerButton.Size = new Size(100, 50); // Размер кнопки
        mainTableManagerButton.Text = "Main table CRUD";
        mainTableManagerButton.Click += this.OpenForm<ManageMainTableForm>; // Подписка на событие нажатия
        
        var voc1ManagerButton = new Button();
        voc1ManagerButton.Location = new Point(200, 150); // Позиция на форме
        voc1ManagerButton.Size = new Size(100, 50); // Размер кнопки
        voc1ManagerButton.Text = "Voc1 CRUD";
        voc1ManagerButton.Click += this.OpenForm<ManageVoc1TableForm>; // Подписка на событие нажатия
        
        var voc2ManagerButton = new Button();
        voc2ManagerButton.Location = new Point(350, 150); // Позиция на форме
        voc2ManagerButton.Size = new Size(100, 50); // Размер кнопки
        voc2ManagerButton.Text = "Voc2 CRUD";
        voc2ManagerButton.Click += this.OpenForm<ManageMainTableForm>; // Подписка на событие нажатия
        
        this.Controls.Add(mainTableManagerButton);
        this.Controls.Add(voc1ManagerButton);
        this.Controls.Add(voc2ManagerButton);
    }
}

public static class Extensions
{
    public static void OpenForm<T>(this Form form, object? sender, EventArgs e) where T : Form, new() => new T().Show();
}