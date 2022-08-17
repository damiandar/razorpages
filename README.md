# razorpages

### Comandos

dotnet new webapp -o ProyRazorPages --no-https

dotnet new page -n PaginaPrueba -o ./Pages/

dotnet new page -n Listado -o Pages/Profesores

dotnet new page -n _FormProfesor -o ./Pages/Shared

## MVVM

No tenemos una carpeta llamada controllers, cada vista tiene una clase C# para procesar las peticiones http.
Tampoco tenemos views, si una carpeta pages.

Cada Page es un 99% parecida MVC, por ejemplo tenemos un @Page en la parte superior para indicar que es una razor pages

Index tiene una indexmodel que hereda de PageModel. 

<strong>OnGet</strong> procesa la peticion http get de nuestra pagina, puedo procesar o devolver una pagina. No hace falta indicarle que tiene que devolver la misma pagina, se sobre entiende.

<strong>OnPost</strong>
Vamos a enviar un parametro hasta nuestro modelo.

```html
<input name="valor1" type="text"/>
<input type="submit" />
```

```
OnPost(string valor1){

}
```

### si queremos pasar un objeto, en mvc hariamos

```
OnPost(Persona persona)
```
En razor pages no es necesario, tenemos que crear el metodo

```
OnPost( )

[BindProperty]
public Persona Persona {get;set;}
```


Podemos tener varios OnPost() dentro del mismo modelo, por ejemplo OnPostAlumnoFormulario()

```html
<input name="valor1" type="text"/>
<input type="submit"  asp-page-handler="AlumnoFormulario" />
```

## Binding

Intercambio entre el modelo y la pagina.

Tambien tenemos un return RedirectToPage("Contact")

## ViewData

En el método OnGet:
```
ViewData["Materias"]
```
Como atributo:
```
[ViewData]
public string Materias { get; set; }
```
En razor:
```html
@page
@model IndexModel
@{
    ViewBag.Title = "My Home Page";
}
```
## Funciones
```html
@functions{


    async System.Threading.Tasks.Task MostrarImagen(string rutafoto) {
        if (String.IsNullOrEmpty(rutafoto))
        {
                <img src="~/images/icono-persona.png" class="rounded-circle" style="width:75px;height:75px;" />
        }
        else { 
                <img src="@Url.Content("~/images/"+ rutafoto)"  class="rounded-circle" style="width:75px;height:75px;" />
        }

    }

    void MostrarActivo(bool activo){
        if(activo){
            <span>SI</span>;
        }
        else{
            <span>NO</span>;
        }
      
    }
 

    void MostrarFechaNacimiento(DateTime dt){
        <span class="date">@dt.ToString("dd/MM/yyyy")   </span>;
    }
    void MostrarEstudioTipo(int tipo){
        var tipoestudio="";
        if(tipo==1){
            tipoestudio="Secundario";
        }
        else if(tipo==2){
            tipoestudio="Terciario";
        }
        else{
            tipoestudio="Universitario";
        }
        <span>@tipoestudio</span>;
    }
      void MostrarEstudioTipo2(int tipo){
         
        if(tipo==1){
            <span class="badge badge-danger">Secundario</span>;
        }
        else if(tipo==2){
                <span class="badge badge-warning">Terciario</span>;
        }
        else{
                <span class="badge badge-success">Universitario</span>;
        }
         
    }
}
```

## Ruteo

La estructura de archivos determina la url que hay que poner para llegar a nuestra pagina.
En startup

Services.AddMvc().AddRazorPagesOptions(o=> o.Conventions.AddPageRoute("/About","acerca-de"));

Entonces http://localhost:5000/acerca-de  nos lleva a about

## Pasar una variable de una pagina a otra utilizando TempData, info primitiva (int, bool, string)

En el Index
```
[TempData]
public string Nombre {get;set;}

OnPost(string param1){
    Nombre=param1;
    return RedirectToPage("Contact")
}
```

En Contact tambien:
```
[TempData]
public string Nombre {get;set;}
```

```html
<span>@Model.Nombre</span>
```


## Pasar una variable de una pagina a otra por querystring

En contact
``` 
 @Page "{id:int}" o   @Page "{id:int?}"
<span>@Model.Mensaje</span>

 public void OnGet(int id){
     Mensaje="Mi mensaje es del id " + id.ToString();
 }
```

## Recibir mas parametros
``` 
 @Page "{id:int}/{pg:int}" 
<span>@Model.Mensaje</span>

 public void OnGet(int id,int pg){
     Mensaje="Mi mensaje es del id " + id.ToString();
     NroPagina=pg;
 }
```

## Ordenamiento

```html
    <a asp-page="./Index" asp-route-sortOrder="@Model.DateSort">
        @Html.DisplayNameFor(model => model.Students[0].EnrollmentDate)
    </a>
```

Y en el método recibe ese sortOrder

```
public OnGet(string sortOrder)
{

}
```
## Exportar sql

dotnet ef migrations script --output "script.sql" --context AppDbContext

## Tag Helpers

## Inyeccion de dependencias

<ul>
<li>
 <strong>Singleton: </strong> significa que solo se creará una única instancia. Esa instancia se comparte entre todos los componentes que la requieren. Por lo tanto, se utiliza siempre la misma instancia.
</li>
<li>
 <strong>Scoped (ambito): </strong> significa que se crea una instancia una vez por ámbito. Se crea un alcance en cada solicitud a la aplicación, por lo que cualquier componente registrado como Con alcance se creará una vez por solicitud.
 </li>
 <li>
 <strong>Transient (transitorio):  </strong>Los servicios creados utilizando el tiempo de vida transitorio se crearán cada vez que se soliciten. Esta vida útil funciona mejor para servicios ligeros.
 </li>
</ul>
    
    > services.AddSingleton<Model.Profesor>();
    
    1. Registrarse como un servicio Scoped para que cada usuario diferente reciba su propia instancia del servicio durante la duración de su sesión. .
    2. Un Singleton permite compartir la misma instancia de una clase de servicio entre componentes. 
    3. Esto es bueno porque desea asegurarse de que todas sus páginas reciban la misma instancia de la clase de servicio Profesor. 
    4. Esto garantizará que los datos (es decir, Legajo, en este ejemplo) se compartan correctamente entre las páginas a lo largo de la vida útil de la aplicación.
    

    > services.AddScoped<Model.Profesor>();

<table>
<tr>
    <td>Service Type</td>
    <td>In the scope of same Http request	Different Http request
        Singleton	The same Instance of repository served	The same Instance of repository served</td>
</tr>
<tr>
    <td>Scoped	</td>
    <td>Same Instance	Different Instance</td>
</tr>
<tr>
    <td>Transient</td>
    <td>Every time New Instance	Every time New Instance</td>
</tr>
</table>

## Agregar iconos

```html
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.1/font/bootstrap-icons.css">
<i class="bi-github" role="img" aria-label="GitHub"></i>
```


# Links

### Environment 
https://www.learnrazorpages.com/razor-pages/tag-helpers/environment-tag-helper


https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-6.0


https://www.learnrazorpages.com/razor-pages/routing


https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-6.0&tabs=visual-studio

https://www.mikesdotnetting.com/article/308/razor-pages-understanding-handler-methods


