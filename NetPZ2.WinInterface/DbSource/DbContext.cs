
using Microsoft.EntityFrameworkCore;

namespace Uni_NET_PZ2.DbSource;

public class MyDbContext : DbContext
{
    public DbSet<MainTable> MainTable = null!;
    
    public MyDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=dataSource.db");
    }

    public List<MainTable> ReadAllFromMainTable()
    {
        return this.MainTable.ToList();
    }
    
    public void Add(MainTable mainTableElement)
    {
        this.MainTable.Add(mainTableElement);
        this.SaveChanges();
    }
    
    public void Delete(int mainTableElementId)
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
}

public class MainTable
{
    public int Id { get; set; }
    public int Voc1Id { get; set; }
    public int Voc2Id { get; set; }
    public string CustomField { get; set; } = "";
}