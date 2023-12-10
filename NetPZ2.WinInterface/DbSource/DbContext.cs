
using Microsoft.EntityFrameworkCore;

namespace Uni_NET_PZ2.DbSource;

public class MyDbContext : DbContext
{
    public DbSet<MainTable> MainTable { get; set; }
    public DbSet<Voc1Table> Voc1Table { get; set; }
    public DbSet<Voc2Table> Voc2Table { get; set; }

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
        this.Voc1Table.Add(voc1);
        this.SaveChanges();
    }
    
    public List<Voc1Table> ReadAllFromVoc1Table()
    {
        return this.Voc1Table.ToList();
    }
    
    public void Update(Voc1Table voc1)
    {
        var oldElement = this.Voc1Table.First(x => x.Id == voc1.Id);
        oldElement.CustomField = voc1.CustomField;
        this.Voc1Table.Update(oldElement);
        this.SaveChanges();
    }
    
    public void DeleteVoc1(int id)
    {
        var oldElement = this.Voc1Table.First(x => x.Id == id);
        this.Voc1Table.Remove(oldElement);
        this.SaveChanges();
    }
    
    public void Add(Voc2Table voc)
    {
        this.Voc2Table.Add(voc);
        this.SaveChanges();
    }
    
    public List<Voc2Table> ReadAllFromVoc2Table()
    {
        return this.Voc2Table.ToList();
    }
    
    public void Update(Voc2Table voc)
    {
        var oldElement = this.Voc2Table.First(x => x.Id == voc.Id);
        oldElement.CustomField = voc.CustomField;
        this.Voc2Table.Update(oldElement);
        this.SaveChanges();
    }
    
    public void DeleteVoc2(int id)
    {
        var oldElement = this.Voc2Table.First(x => x.Id == id);
        this.Voc2Table.Remove(oldElement);
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

public class Voc2Table
{
    public int Id { get; set; }
    public string CustomField { get; set; } = "";
}