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

