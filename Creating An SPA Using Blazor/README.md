# Creating An SPA Using Blazor
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- SQL Server 2014
- Visual Studio 2017
- ASP.NET Core 2.0
- Razor Pages
- Blazor
## Topics
- Blazor
- ASP.NET Core Blazor
## Updated
- 06/06/2018
## Description

<h1><span>Introduction</span></h1>
<p>In this article, we are going to create a Single Page Application (SPA) using Razor pages in Blazor with the help of Entity Framework Core database first approach. Single-Page Applications are web application that load a single HTML page and dynamically
 update that page as the user interacts with the app.&nbsp;We will be creating a sample Employee Record Management System and perform CRUD operations on it.</p>
<p>We will be using Visual Studio 2017 and SQL Server 2014.</p>
<p>Take a look at the final application.</p>
<p><span><br>
</span></p>
<p><span><img id="200946" src="200946-blazorwithrazor.gif" alt=""><br>
</span></p>
<h1><span>Prerequisites</span></h1>
<ul>
<li>Install .NET Core 2.1 Preview 2 SDK from&nbsp;<a href="https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300-preview2">here</a>
</li><li>Install Visual Studio 2017 v15.7 or above from&nbsp;<a href="https://www.visualstudio.com/downloads/">here</a>
</li><li>Install ASP.NET Core Blazor Language Services extension from&nbsp;<a href="https://marketplace.visualstudio.com/items?itemName=aspnet.blazor">here</a>
</li><li>SQL Server 2008 or above </li></ul>
<p>Blazor framework is not supported by versions below Visual Studio 2017 v15.7.</p>
<h1><span>Creating Table</span></h1>
<p>We will be using a DB table to store all the records of employees.</p>
<p>Open SQL Server and use the following script to create&nbsp;<em>Employee</em>&nbsp;table.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span><span class="sql__keyword">TABLE</span><span class="sql__id">Employee</span>&nbsp;(&nbsp;&nbsp;&nbsp;
<span class="sql__id">EmployeeID</span><span class="sql__keyword">int</span><span class="sql__id">IDENTITY</span>(<span class="sql__number">1</span>,<span class="sql__number">1</span>)&nbsp;<span class="sql__keyword">PRIMARY</span><span class="sql__keyword">KEY</span>,&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">Name</span><span class="sql__keyword">varchar</span>(<span class="sql__number">20</span>)&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>&nbsp;,&nbsp;&nbsp;&nbsp;
<span class="sql__id">City</span><span class="sql__keyword">varchar</span>(<span class="sql__number">20</span>)&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>&nbsp;,&nbsp;&nbsp;&nbsp;
<span class="sql__id">Department</span><span class="sql__keyword">varchar</span>(<span class="sql__number">20</span>)&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>&nbsp;,&nbsp;&nbsp;&nbsp;
<span class="sql__id">Gender</span><span class="sql__keyword">varchar</span>(<span class="sql__number">6</span>)&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;</pre>
</div>
</div>
</div>
<h1><span>Create Blazor Web Application</span></h1>
<p>Open Visual Studio and select File &gt;&gt; New &gt;&gt; Project.</p>
<p>After selecting the project, a &ldquo;New Project&rdquo; dialog will open. Select .NET Core inside Visual C# menu from the left panel.&nbsp;Then, select &ldquo;ASP.NET Core Web Application&rdquo; from available project types. Put the name of the project
 as&nbsp;<em>BlazorSPA&nbsp;</em>and press OK.</p>
<p><img id="200947" src="200947-createproject.png" alt=""></p>
<p><span>After clicking on OK, a new dialog will open asking you to select the project template. You can observe two drop-down menus at the top left of the template window. Select &ldquo;.NET Core&rdquo; and &ldquo;ASP.NET Core 2.0&rdquo; from these dropdowns.
 Then, select &ldquo;Blazor (ASP .NET Core hosted)&rdquo; template and press OK.</span></p>
<p><img id="200948" src="200948-createproject_1.png" alt="" width="650" height="457"></p>
<p><span>Now, our Blazor solution will be created. You can observe the folder structure in Solution Explorer as shown in the below image.</span></p>
<p><img id="200949" src="200949-solexp_1.png" alt="" width="268" height="544"></p>
<p>You can observe that we have three project files created inside this solution.</p>
<ol>
<li>BlazorSPA.Client &ndash; It has the client side code and contains the pages that will be rendered on the browser.
</li><li>BlazorSPA.Server &ndash; It has the server side codes such as DB related operations and web API.
</li><li>BlazorSPA.Shared &ndash; It contains the shared code that can be accessed by both client and server. It contains out Model classes.
</li></ol>
<h1><span>Scaffolding the Model to the Application</span></h1>
<p>We are using Entity Framework core database first approach to create our models. We will create our model class in BlazorSPA.Shared project so that it can be accessible to both client and server project.</p>
<p>Navigate to Tools &gt;&gt; NuGet Package Manager &gt;&gt; Package Manager Console. Select &ldquo;BlazorSPA.Shared&rdquo; from Default project drop-down. Refer to image below:</p>
<p><img id="200950" src="200950-nugetconsole.png" alt="" width="650" height="71"></p>
<p><span>First, we will install the package for the database provider that we are targeting which is SQL Server in this case. Hence, run the following command,</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>

<div class="preview">
<pre class="windowsshell">Install<span class="windowsshell__commandext">-Package</span>&nbsp;Microsoft.EntityFrameworkCore.SqlServer</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Since we are using Entity Framework Tools to create a model from the existing database, we will install the tools package as well. Hence, run the following command</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>

<div class="preview">
<pre class="windowsshell">Install<span class="windowsshell__commandext">-Package</span>&nbsp;Microsoft.EntityFrameworkCore.Tools</pre>
</div>
</div>
</div>
<span>After you have installed both the packages, we will scaffold our model from the database tables using the following command,</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>

<div class="preview">
<pre class="windowsshell">Scaffold<span class="windowsshell__commandext">-DbContext</span><span class="windowsshell__string">&quot;Your&nbsp;connection&nbsp;string&nbsp;here&quot;</span>&nbsp;Microsoft.EntityFrameworkCore.SqlServer&nbsp;<span class="windowsshell__commandext">-OutputDir</span>&nbsp;Models&nbsp;<span class="windowsshell__commandext">-Tables</span>&nbsp;Employee</pre>
</div>
</div>
</div>
<p>Do not forget to put your own connection string (inside &rdquo; &ldquo;). After this command is executed successfully, you can observe a Models folder has been created and it contains two class files&nbsp;<em>myTestDBContext.cs&nbsp;</em>and&nbsp;<em>Employee.cs</em>.
 Hence, we have successfully scaffolded our Models using EF core database first approach.</p>
<p>At this point in time, the Models folder will have the following structure.</p>
<p><img id="200951" src="200951-solexp_2.png" alt=""></p>
<h1><span><span>Creating Data Access Layer for the Application</span></span></h1>
<p><span>Right-click on BlazorSPA.Server project and then select Add &gt;&gt; New Folder and name the folder as&nbsp;<em>DataAccess</em>. We will be adding our class to handle database related operations inside this folder only.</span></p>
<p><span>Right click on&nbsp;<em>DataAccess</em>&nbsp;folder and select Add &gt;&gt; Class. Name your class&nbsp;<em><span>EmployeeDataAccessLayer</span>.cs</em>.</span></p>
<p><span>Open&nbsp;<em><span>EmployeeDataAccessLayer</span>.cs&nbsp;</em>and put the following code into it.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;BlazorSPA.Shared.Models;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.EntityFrameworkCore;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;BlazorSPA.Server.DataAccess&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;EmployeeDataAccessLayer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myTestDBContext&nbsp;db&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;myTestDBContext();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//To&nbsp;Get&nbsp;all&nbsp;employees&nbsp;details&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;Employee&gt;&nbsp;GetAllEmployees()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;db.Employee.ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//To&nbsp;Add&nbsp;new&nbsp;employee&nbsp;record&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddEmployee(Employee&nbsp;employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Employee.Add(employee);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//To&nbsp;Update&nbsp;the&nbsp;records&nbsp;of&nbsp;a&nbsp;particluar&nbsp;employee&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;UpdateEmployee(Employee&nbsp;employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Entry(employee).State&nbsp;=&nbsp;EntityState.Modified;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;details&nbsp;of&nbsp;a&nbsp;particular&nbsp;employee&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Employee&nbsp;GetEmployeeData(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Employee&nbsp;employee&nbsp;=&nbsp;db.Employee.Find(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;employee;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//To&nbsp;Delete&nbsp;the&nbsp;record&nbsp;of&nbsp;a&nbsp;particular&nbsp;employee&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteEmployee(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Employee&nbsp;emp&nbsp;=&nbsp;db.Employee.Find(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Employee.Remove(emp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span>Here we have defined methods to handle database operations.&nbsp;</span><em>GetAllEmployees</em><span>&nbsp;will fetch all the employee data from Employee Table. Similarly,&nbsp;</span><em>AddEmployee</em><span>&nbsp;will create a new employee record
 and&nbsp;</span><em>UpdateEmployee</em><span>&nbsp;will update the record of an existing employee. GetEmployeeData will fetch the record of the employee corresponding to the employee ID passed to it and&nbsp;</span><em>DeleteEmployee</em><span>&nbsp;will delete
 the employee record corresponding to the employee id passed to it.</span></p>
<h1><span>Adding the web API Controller to the Application</span></h1>
<p>Right click on&nbsp;<em>BlazorSPA.Server/Controllers</em>&nbsp;folder and select Add &gt;&gt; New Item. An &ldquo;Add New Item&rdquo; dialog box will open. Select&nbsp;<em>ASP.NET</em>&nbsp;from the left panel, then select &ldquo;API Controller Class&rdquo;
 from templates panel and put the name as&nbsp;<em>EmployeeController.cs</em>. Click Add.</p>
<p><img id="200952" src="200952-addcontroller.png" alt=""></p>
<p>This will create our API&nbsp;<em>EmployeeController&nbsp;</em>class.</p>
<p>We will call the methods of&nbsp;<em>EmployeeDataAccessLayer&nbsp;</em>class&nbsp;to fetch data and pass on the data to the client side.</p>
<p>Open&nbsp;<em>EmployeeController.cs&nbsp;</em>file and put the following code into it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;BlazorSPA.Server.DataAccess;&nbsp;
<span class="cs__keyword">using</span>&nbsp;BlazorSPA.Shared.Models;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.Mvc;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;BlazorSPA.Server.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;EmployeeController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EmployeeDataAccessLayer&nbsp;objemployee&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EmployeeDataAccessLayer();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/Employee/Index&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;Employee&gt;&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;objemployee.GetAllEmployees();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/Employee/Create&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Create([FromBody]&nbsp;Employee&nbsp;employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objemployee.AddEmployee(employee);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/Employee/Details/{id}&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Employee&nbsp;Details(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;objemployee.GetEmployeeData(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPut]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/Employee/Edit&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Edit([FromBody]Employee&nbsp;employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objemployee.UpdateEmployee(employee);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpDelete]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;api/Employee/Delete/{id}&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Delete(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objemployee.DeleteEmployee(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span>At this point of time, our BlazorSPA.Server project has the following structure.</span></p>
<p><span><img id="200953" src="200953-solexp_3.png" alt="" width="369" height="423"><br>
</span></p>
<p><span>We are done with our backend logic. Therefore, we will now proceed to code our client side.</span></p>
<h1><span>Adding Razor Page to the Application</span></h1>
<p>We will add the Razor page in&nbsp;<em>BlazorSPA.Client/Pages</em>&nbsp;folder. By default, we have &ldquo;Counter&rdquo; and &ldquo;Fetch Data&rdquo; pages provided in our application. These default pages will not affect our application but for the sake
 of this tutorial, we will delete&nbsp;<em>fetchdata&nbsp;</em>and&nbsp;<em>counter</em>&nbsp;pages&nbsp;from BlazorSPA.Client/Pages&nbsp;folder.</p>
<p>Right click on&nbsp;<em>BlazorSPA.Client/Pages</em>&nbsp;folder and then select Add &gt;&gt; New Item. An &ldquo;Add New Item&rdquo; dialog box will open, select &ldquo;ASP.NET Core&rdquo; from the left panel, then select &ldquo;Razor Page&rdquo; from templates
 panel and name it&nbsp;<em>EmployeeData.cshtml</em>.&nbsp;Click Add.</p>
<p><img id="200954" src="200954-addrazorpage.png" alt="" width="650" height="370"></p>
<p>This will add an&nbsp;<em>EmployeeData.cshtml</em>&nbsp;page to our&nbsp;<em>BlazorSPA.Client/Pages</em>&nbsp;folder. This razor page will have two files,&nbsp;<em>EmployeeData.cshtml&nbsp;</em>and<em>&nbsp;EmployeeData.cshtml.cs.</em></p>
<p>Now we will add codes to these pages.</p>
<h1><span>EmployeeData.cshtml.cs</span></h1>
<p>Open&nbsp;<em>EmployeeData.cshtml.cs&nbsp;</em>and put the following code into it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.Http.aspx" target="_blank" title="Auto generated link to System.Net.Http">System.Net.Http</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;BlazorSPA.Shared.Models;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.Blazor;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.Blazor.Components;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.Blazor.Services;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;BlazorSPA.Client.Pages&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;EmployeeDataModel&nbsp;:&nbsp;BlazorComponent&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Inject]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;HttpClient&nbsp;Http&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Inject]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;IUriHelper&nbsp;UriHelper&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Parameter]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span><span class="cs__keyword">string</span>&nbsp;paramEmpID&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;=&nbsp;<span class="cs__string">&quot;0&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Parameter]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span><span class="cs__keyword">string</span>&nbsp;action&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;List&lt;Employee&gt;&nbsp;empList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Employee&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;Employee&nbsp;emp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Employee();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span><span class="cs__keyword">string</span>&nbsp;title&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span><span class="cs__keyword">override</span>&nbsp;async&nbsp;Task&nbsp;OnInitAsync()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;FetchEmployee();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;async&nbsp;Task&nbsp;FetchEmployee()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title&nbsp;=&nbsp;<span class="cs__string">&quot;Employee&nbsp;Data&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;empList&nbsp;=&nbsp;await&nbsp;Http.GetJsonAsync&lt;List&lt;Employee&gt;&gt;(<span class="cs__string">&quot;api/Employee/Index&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span><span class="cs__keyword">override</span>&nbsp;async&nbsp;Task&nbsp;OnParametersSetAsync()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(action&nbsp;==&nbsp;<span class="cs__string">&quot;create&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title&nbsp;=&nbsp;<span class="cs__string">&quot;Add&nbsp;Employee&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Employee();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span><span class="cs__keyword">if</span>&nbsp;(paramEmpID&nbsp;!=&nbsp;<span class="cs__string">&quot;0&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(action&nbsp;==&nbsp;<span class="cs__string">&quot;edit&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title&nbsp;=&nbsp;<span class="cs__string">&quot;Edit&nbsp;Employee&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span><span class="cs__keyword">if</span>&nbsp;(action&nbsp;==&nbsp;<span class="cs__string">&quot;delete&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title&nbsp;=&nbsp;<span class="cs__string">&quot;Delete&nbsp;Employee&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emp&nbsp;=&nbsp;await&nbsp;Http.GetJsonAsync&lt;Employee&gt;(<span class="cs__string">&quot;/api/Employee/Details/&quot;</span>&nbsp;&#43;&nbsp;Convert.ToInt32(paramEmpID));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;async&nbsp;Task&nbsp;CreateEmployee()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(emp.EmployeeId&nbsp;!=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Http.SendJsonAsync(HttpMethod.Put,&nbsp;<span class="cs__string">&quot;api/Employee/Edit&quot;</span>,&nbsp;emp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Http.SendJsonAsync(HttpMethod.Post,&nbsp;<span class="cs__string">&quot;/api/Employee/Create&quot;</span>,&nbsp;emp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UriHelper.NavigateTo(<span class="cs__string">&quot;/employee/fetch&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;FetchEmployee();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.StateHasChanged();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;async&nbsp;Task&nbsp;DeleteEmployee()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Http.DeleteAsync(<span class="cs__string">&quot;api/Employee/Delete/&quot;</span>&nbsp;&#43;&nbsp;Convert.ToInt32(paramEmpID));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UriHelper.NavigateTo(<span class="cs__string">&quot;/employee/fetch&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;FetchEmployee();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.StateHasChanged();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span><span class="cs__keyword">void</span>&nbsp;Cancel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title&nbsp;=&nbsp;<span class="cs__string">&quot;Employee&nbsp;Data&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UriHelper.NavigateTo(<span class="cs__string">&quot;/employee/fetch&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.StateHasChanged();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>Let us understand this code. We have defined a class&nbsp;<em>EmployeeDataModel&nbsp;</em>that will hold all our methods that we will use in&nbsp;<em>EmployeeData.cshtml&nbsp;</em>page.</p>
<p>We are injecting the&nbsp;<em>HttpClient</em>&nbsp;service to enable web API call and&nbsp;<em>IUriHelper</em>&nbsp;service to enable URL redirection. After this, we have defined our parameter attributes &ndash;&nbsp;<em>paramEmpID</em>&nbsp;and&nbsp;<em>action</em>.
 These parameters are used in&nbsp;<em>EmployeeData.cshtml</em>&nbsp;to define the routes for our page. We have also declared a property&nbsp;<em>title</em>&nbsp;to display the heading to specify the current action that is being performed on the page.&nbsp;</p>
<p><em>OnParametersSetAsync</em>&nbsp;method is invoked every time the URL parameters are set for the page. We will check the value of parameter &ldquo;action&rdquo; to identify the current operation on the page. If the action is set to &ldquo;fetch&rdquo;,
 then we will invoke&nbsp;<em>FetchEmployee</em>&nbsp;method to fetch the updated list of employees from the database and refresh the UI using&nbsp;<em>StateHasChanged</em>&nbsp;method. We will check if the action attribute of parameter is set to &ldquo;create&rdquo;,
 then we will set the title of page to &ldquo;Add Employee&rdquo; and create a new object of type Employee. If the paramEmpID is not &ldquo;0&rdquo;, then it is either an edit action or a delete action. We will set the title property accordingly and then invoke
 our web API method to fetch the data for the employee id as set in&nbsp;<em>paramEmpID</em>&nbsp;property.</p>
<p>The method FetchEmployee will set the title to &ldquo;Employee Data&rdquo; and fetch all the employee data by invoking our web API method.</p>
<p>The&nbsp;<em>CreateEmployee</em>&nbsp;method will check if it is invoked to add a new employee record or to edit an existing employee record. If the EmployeeId property is set then it is an &ldquo;edit&rdquo; request and we will send a PUT request to web
 API. If EmployeeId is not set then it is a &ldquo;create&rdquo; request and we will send a POST request to web API. We will set the title property according to the corresponding value of action and then invoke our web API method to fetch the data for the employee
 id as set in&nbsp;<em>paramEmpID&nbsp;</em>property.</p>
<p>The <em>DeleteEmployee</em> method will delete the employee record for the employee id as set in&nbsp;<em>paramEmpID</em>&nbsp;property. After deletion, the user is redirected to &ldquo;/employee/fetch&rdquo; page.</p>
<p>In the&nbsp;<em>Cancel</em>&nbsp;method we will set the title property to &ldquo;Employee Data&rdquo; and redirect the user to &ldquo;/employee/fetch&rdquo; page<span>.</span></p>
<h1><span>EmployeeData.cshtml</span></h1>
<p>Open&nbsp;<em>EmployeeData.cshtml</em>&nbsp;page and put the following code into it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@page&nbsp;&quot;/employee/{action}/{paramEmpID}&quot;&nbsp;
@page&nbsp;&quot;/employee/{action}&quot;&nbsp;
@inherits&nbsp;EmployeeDataModel&nbsp;
&nbsp;
<span class="html__tag_start">&lt;h1</span><span class="html__tag_start">&gt;@</span>title<span class="html__tag_end">&lt;/h1&gt;</span>&nbsp;
&nbsp;
@if&nbsp;(action&nbsp;==&nbsp;&quot;fetch&quot;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;a</span><span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/employee/create&quot;</span><span class="html__tag_start">&gt;</span>Create&nbsp;New<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
}&nbsp;
&nbsp;
@if&nbsp;(action&nbsp;==&nbsp;&quot;create&quot;&nbsp;||&nbsp;action&nbsp;==&nbsp;&quot;edit&quot;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;table</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;label</span><span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;Name&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span>Name<span class="html__tag_end">&lt;/label&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;input</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span><span class="html__attr_name">bind</span>=<span class="html__attr_value">&quot;@emp.Name&quot;</span><span class="html__tag_start">/&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;20&quot;</span><span class="html__tag_start">&gt;&nbsp;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;label</span><span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;Department&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span>Department<span class="html__tag_end">&lt;/label&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;input</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span><span class="html__attr_name">bind</span>=<span class="html__attr_value">&quot;@emp.Department&quot;</span><span class="html__tag_start">/&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span><span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;label</span><span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;Gender&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span>Gender<span class="html__tag_end">&lt;/label&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;select</span><span class="html__attr_name">asp-for</span>=<span class="html__attr_value">&quot;Gender&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span><span class="html__attr_name">bind</span>=<span class="html__attr_value">&quot;@emp.Gender&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;option</span><span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;&quot;</span><span class="html__tag_start">&gt;-</span>-&nbsp;Select&nbsp;Gender&nbsp;--<span class="html__tag_end">&lt;/option&gt;</span><span class="html__tag_start">&lt;option</span><span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Male&quot;</span><span class="html__tag_start">&gt;</span>Male<span class="html__tag_end">&lt;/option&gt;</span><span class="html__tag_start">&lt;option</span><span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Female&quot;</span><span class="html__tag_start">&gt;</span>Female<span class="html__tag_end">&lt;/option&gt;</span><span class="html__tag_end">&lt;/select&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;20&quot;</span><span class="html__tag_start">&gt;&nbsp;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;label</span><span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;City&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control-label&quot;</span><span class="html__tag_start">&gt;</span>City<span class="html__tag_end">&lt;/label&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;input</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span><span class="html__attr_name">bind</span>=<span class="html__attr_value">&quot;@emp.City&quot;</span><span class="html__tag_start">/&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span><span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;input</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;submit&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-success&quot;</span>&nbsp;onclick=&quot;@(async&nbsp;()&nbsp;=<span class="html__tag_start">&gt;&nbsp;</span>await&nbsp;CreateEmployee())&quot;&nbsp;style=&quot;width:220px;&quot;&nbsp;value=&quot;Save&quot;&nbsp;<span class="html__tag_end">/&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;20&quot;</span><span class="html__tag_start">&gt;&nbsp;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;input</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;submit&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-danger&quot;</span><span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;@Cancel&quot;</span><span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;width:220px;&quot;</span><span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Cancel&quot;</span><span class="html__tag_start">/&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span><span class="html__tag_end">&lt;/table&gt;</span><span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
}&nbsp;
else&nbsp;if&nbsp;(action&nbsp;==&nbsp;&quot;delete&quot;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-4&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;table</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;table&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;</span>Name<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;@</span>emp.Name<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span><span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;</span>Gender<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;@</span>emp.Gender<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span><span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;</span>Department<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;@</span>emp.Department<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span><span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;</span>City<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;@</span>emp.City<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span><span class="html__tag_end">&lt;/table&gt;</span><span class="html__tag_start">&lt;div</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;input</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;submit&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-danger&quot;</span>&nbsp;onclick=&quot;@(async&nbsp;()&nbsp;=<span class="html__tag_start">&gt;&nbsp;</span>await&nbsp;DeleteEmployee())&quot;&nbsp;value=&quot;Delete&quot;&nbsp;<span class="html__tag_end">/&gt;</span><span class="html__tag_start">&lt;input</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;submit&quot;</span><span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Cancel&quot;</span><span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;@Cancel&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&quot;</span><span class="html__tag_start">/&gt;</span><span class="html__tag_end">&lt;/div&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
}&nbsp;
&nbsp;
@if&nbsp;(empList&nbsp;==&nbsp;null)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;em</span><span class="html__tag_start">&gt;</span>Loading...<span class="html__tag_end">&lt;/em&gt;</span><span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
}&nbsp;
else&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;table</span><span class="html__attr_name">class</span>=<span class="html__attr_value">'table'</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;thead</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;</span>ID<span class="html__tag_end">&lt;/th&gt;</span><span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;</span>Name<span class="html__tag_end">&lt;/th&gt;</span><span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;</span>Gender<span class="html__tag_end">&lt;/th&gt;</span><span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;</span>Department<span class="html__tag_end">&lt;/th&gt;</span><span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;</span>City<span class="html__tag_end">&lt;/th&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span><span class="html__tag_end">&lt;/thead&gt;</span><span class="html__tag_start">&lt;tbody</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@foreach&nbsp;(var&nbsp;emp&nbsp;in&nbsp;empList)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;@</span>emp.EmployeeId<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;@</span>emp.Name<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;@</span>emp.Gender<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;@</span>emp.Department<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;@</span>emp.City<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;a</span><span class="html__attr_name">href</span>=<span class="html__attr_value">'/employee/edit/@emp.EmployeeId'</span><span class="html__tag_start">&gt;</span>Edit<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;&nbsp;|&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span><span class="html__attr_name">href</span>=<span class="html__attr_value">'/employee/delete/@emp.EmployeeId'</span><span class="html__tag_start">&gt;</span>Delete<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tbody&gt;</span><span class="html__tag_end">&lt;/table&gt;</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p>At the top, we have defined the routes for our page. There are two routes defined.</p>
<ol>
<li>/employee/{action}/{paramEmpID} : This will accept action name along with employee id. This route is invoked when we perform&nbsp;<em>Edit</em>&nbsp;or&nbsp;<em>Delete&nbsp;</em>operation<em>.</em>&nbsp;When we call edit or delete action on a particular
 employee data, the employee id is also passed as the URL parameter. </li><li>/employee/{action} : This will only accept the action name. This route is invoked when we create a new employee data or we fetch the records of all the employees.
</li></ol>
<p>We are also inheriting&nbsp;<em>EmployeeDataModel</em>&nbsp;class, which is defined in&nbsp;<em>EmployeeData.cshtml.cs</em>&nbsp;file. This will allow us to use the methods defined in EmployeeDataModel class.</p>
<p>After this, we are setting the title that will be displayed on our page. The title is dynamic and change as per the action that is being executed currently on the page.</p>
<p>We will show the &ldquo;Create New&rdquo; link only if the action is &ldquo;fetch&rdquo;. If the action is&nbsp;<em>create</em>&nbsp;or&nbsp;<em>edit</em>&nbsp;then &ldquo;Create New&rdquo; link will be hidden and we will display the form to get the user
 input. Inside the form, we have also defined two buttons &ldquo;Save&rdquo; and &ldquo;Cancel&rdquo;. Clicking on&nbsp;<em>Save</em>&nbsp;will invoke the &ldquo;CreateEmployee&rdquo; method whereas clicking on&nbsp;<em>Cancel</em>&nbsp;will invoke the &ldquo;Cancel&rdquo;
 method.</p>
<p>If the action is delete then a table will be displayed with the data of the employee on which the delete action is invoked. We are also displaying two buttons &ndash; &ldquo;Delete&rdquo; and &ldquo;Cancel&rdquo;. On clicking of&nbsp;<em>Delete</em>&nbsp;button,
 &ldquo;DeleteEmployee&rdquo; method will be invoked and clicking on&nbsp;<em>Cancel</em>&nbsp;will invoke the &ldquo;Cancel&rdquo; method.</p>
<p>At the end, we have a table to display all the employee data from the database. Each employee record will also have two action links,&nbsp;<em>Edit</em>&nbsp;to edit the employee record and&nbsp;<em>Delete</em>&nbsp;to delete the employee record.&nbsp;This
 table is always displayed on the page and we will update it after performing every action.</p>
<h1><span>Adding Link to Navigation menu</span></h1>
<p>The last step is to add the link to our &ldquo;EmployeeData&rdquo; page in the navigation menu, open&nbsp;<em>BlazorSPA.Client/Shared/NavMenu.cshtml</em>&nbsp;page and put the following code into it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;top-row&nbsp;pl-4&nbsp;navbar&nbsp;navbar-dark&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;navbar-brand&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/&quot;</span><span class="html__tag_start">&gt;</span>BlazorSPA<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;navbar-toggler&quot;</span>&nbsp;onclick=@ToggleNavMenu<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;navbar-toggler-icon&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;class=@(collapseNavMenu&nbsp;?&nbsp;&quot;collapse&quot;&nbsp;:&nbsp;null)&nbsp;onclick=@ToggleNavMenu<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ul</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav&nbsp;flex-column&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-item&nbsp;px-3&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;NavLink</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-link&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/&quot;</span>&nbsp;Match=NavLinkMatch.All<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;oi&nbsp;oi-home&quot;</span>&nbsp;<span class="html__attr_name">aria-hidden</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;Home&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/NavLink&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-item&nbsp;px-3&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;NavLink</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-link&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/employee/fetch&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;oi&nbsp;oi-list-rich&quot;</span>&nbsp;<span class="html__attr_name">aria-hidden</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;Employee&nbsp;data&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/NavLink&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/ul&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
@functions&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;collapseNavMenu&nbsp;=&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;void&nbsp;ToggleNavMenu()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;collapseNavMenu&nbsp;=&nbsp;!collapseNavMenu;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span>Hence, we have successfully created a Single Page Application (SPA) using Blazor with the help of Entity Framework Core database first approach.</span></p>
<h1><span>Execution Demo</span></h1>
<p>Launch the application.</p>
<p>A web page will open as shown in the image below. The navigation menu on the left is showing navigation link for Employee data page.</p>
<p><img id="200955" src="200955-home.png" alt="" width="650" height="377"></p>
<p><span>Click on &ldquo;Employee data&rdquo; link, it will redirect to EmployeeData view. Here you can see all the employee data on the page. Notice the URL has &ldquo;employee/fetch&rdquo; appended to it.</span></p>
<p><img id="200956" src="200956-fetch_1.png" alt="" width="650" height="295"></p>
<p><span>Since we have not added any data, hence it is empty. Click on&nbsp;</span><em>CreateNew</em><span>&nbsp;to open &ldquo;Add Employee&rdquo; form to add a new employee data. Notice the URL has &ldquo;employee/create&rdquo; appended to it.</span></p>
<p><img id="200957" src="200957-addemp.png" alt="" width="650" height="346"></p>
<p><span>After inserting data in all the fields, click on &ldquo;Save&rdquo; button. The new employee record will be created&nbsp;and the Employee data table will get refreshed.</span></p>
<p><img id="200958" src="200958-fetch_2.png" alt=""></p>
<p><span>If we want to edit an existing employee record, then click on Edit action link. It will open Edit view as shown below. Here we can change the employee data. Notice that we have passed the employee id in the URL parameter.</span></p>
<p><span><img id="200959" src="200959-edit.png" alt=""><br>
</span></p>
<p><span>Here we have changed the City of employee Swati from Mumbai to Kolkatta. Click on &ldquo;Save&rdquo; to refresh the employee data table to view the updated changes as highlighted in the image below:</span></p>
<p><img id="200960" src="200960-fetch_3.png" alt=""></p>
<p><span>Now, we will perform Delete operation on the employee named Dhiraj. Click on Delete action link which will open Delete view asking for a confirmation to delete. Notice that we have passed the employee id in the URL parameter.</span></p>
<p><span><img id="200961" src="200961-delete.png" alt=""><br>
</span></p>
<p><span>Once we click on Delete button, it will delete the employee record and the employee data table will be refreshed. Here, we can see that the employee with name Dhiraj has been removed from our record.</span></p>
<p><span><img id="200962" src="200962-fetch_4.png" alt="" width="650" height="318"></span></p>
<h1>Deploying the application</h1>
<p><span><span>To learn how to deploy a Blazor application using IIS , refer to&nbsp;</span><a href="https://social.technet.microsoft.com/wiki/contents/articles/51588.blazor-deploying-an-application-on-iis-10.aspx" target="_blank">Blazor: Deploying An Application
 On IIS 10</a><span>.</span><br>
</span></p>
<h1>Conclusion</h1>
<p>We have created a Single Page Application with Razor pages in Blazor using the Entity Framework Core database first approach with the help of Visual Studio 2017 and SQL Server 2014. We have also performed the CRUD operations on our application.</p>
<p><span>Please download the source code and play around for better understanding.</span></p>
<h1>See Also</h1>
<ul>
<li><a rel="noopener" href="http://ankitsharmablogs.com/asp-net-core-getting-started-with-blazor/" target="_blank">ASP.NET Core &ndash; Getting Started With Blazor</a>
</li><li><a rel="noopener" href="http://ankitsharmablogs.com/asp-net-core-crud-using-blazor-and-entity-framework-core/" target="_blank">ASP.NET Core &ndash; CRUD Using Blazor And Entity Framework Core</a>
</li><li><a rel="noopener" href="http://ankitsharmablogs.com/cascading-dropdownlist-in-blazor-using-ef-core/" target="_blank">Cascading DropDownList In Blazor Using EF Core</a>
</li><li><a rel="noopener" href="https://www.c-sharpcorner.com/article/razor-page-web-application-with-asp-net-core-using-ado-net/" target="_blank">Razor Page Web Application With ASP.NET Core Using ADO.NET</a>
</li><li><a rel="noopener" href="http://ankitsharmablogs.com/asp-net-core-crud-using-angular-5-and-entity-framework-core/" target="_blank">ASP.NET Core &ndash; CRUD Using Angular 5 And Entity Framework Core</a>
</li><li><a rel="noopener" href="http://ankitsharmablogs.com/asp-net-core-crud-with-react-js-and-entity-framework-core/" target="_blank">ASP.NET Core &ndash; CRUD With React.js And Entity Framework Core</a>
</li></ul>
