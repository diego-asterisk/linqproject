# Linq Project
Uso de LinQ en C#
## Operadores

Operador Where
```cs
librosCollection.Where(x => x.PageCount > 250 && x.Title.Contains("in Action"));
```

Operador All
```cs
librosCollection.All(x => x.Status != string.Empty);
```

Operador Any
```cs
librosCollection.Any(x => x.PublishedDate.Year == 2005);
```

Operador Contains
```cs
librosCollection.Where(x => x.Categories.Contains("Python"));
```

Operador LongCount
```cs
librosCollection.LongCount( l => l.PageCount >= 200 && l.PageCount <= 500 );
```

Operador Max
```cs
librosCollection.Max(x => x.PublishedDate);
```

Operador MinBy
```cs
book = librosCollection.MinBy(x => x.PageCount);
```

Operador Average
```cs
book = librosCollection.Average(x => x.PageCount);
```
Operador Agregate
```cs
book = librosCollection.Agregate(seed, (accumulator, next) => { Acumular(accumulator, next); return accumulator; } );
```

### Operadores de agrupamiento

Operador GroupBy
```cs
book = librosCollection.GroupBy( p => p.PublishedDate.Year );
```
Operador ToLookup
```cs
book = librosCollection.ToLookup(p => p.Title[0], b => b);
```
Operador Join
```cs
book = coleccionA.Join( coleccionB, p => p.Id, q => q.otroId, (p, q) => p);
```
