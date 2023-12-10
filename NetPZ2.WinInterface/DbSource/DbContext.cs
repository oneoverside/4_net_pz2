
using Microsoft.EntityFrameworkCore;

namespace Uni_NET_PZ2.DbSource;

public class MyDbContext : DbContext
{
    public DbSet<MainTable> MainTable;
    public DbSet<Voc1Table> Voc1;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=dataSource.db");
    }
    
    public void InitializeDatabase()
    {
        this.Database.EnsureCreated();
    }
    
    public void Add(MainTable mainTableElement)
    {
        this.MainTable.Add(mainTableElement);
        this.SaveChanges();
    }
    
    public List<MainTable> ReadAllFromMainTable()
    {
        return this.MainTable.ToList();
    }
    
    public void DeleteMain(int mainTableElementId)
    {
        var oldElement = this.MainTable.First(x => x.Id == mainTableElementId);
        this.MainTable.Remove(oldElement);
        this.SaveChanges();
    }
    
    public void Update(MainTable mainTableElement)
    {
        var oldElement = this.MainTable.First(x => x.Id == mainTableElement.Id);
        oldElement.CustomField = mainTableElement.CustomField;
        oldElement.Voc1Id = mainTableElement.Voc1Id;
        oldElement.Voc2Id = mainTableElement.Voc2Id; 
        this.MainTable.Update(oldElement);
        this.SaveChanges();
    }

    public void Add(Voc1Table voc1)
    {
        this.Voc1.Add(voc1);
        this.SaveChanges();
    }
    
    public List<MainTable> ReadAllFromVoc1Table()
    {
        return this.MainTable.ToList();
    }
    
    public void Update(Voc1Table voc1)
    {
        var oldElement = this.Voc1.First(x => x.Id == voc1.Id);
        oldElement.CustomField = voc1.CustomField;
        this.Voc1.Update(oldElement);
        this.SaveChanges();
    }
    
    public void DeleteVoc1(int id)
    {
        var oldElement = this.MainTable.First(x => x.Id == id);
        this.MainTable.Remove(oldElement);
        this.SaveChanges();
    }
}

public class MainTable
{
    public int Id { get; set; }
    public int Voc1Id { get; set; }
    public int Voc2Id { get; set; }
    public string CustomField { get; set; } = "";
}

public class Voc1Table
{
    public int Id { get; set; }
    public string CustomField { get; set; } = "";
}