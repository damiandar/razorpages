# razorpages


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

https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-6.0


https://www.learnrazorpages.com/razor-pages/routing
