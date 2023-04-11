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

