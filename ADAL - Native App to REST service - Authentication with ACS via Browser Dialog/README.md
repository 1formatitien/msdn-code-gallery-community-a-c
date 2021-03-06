# ADAL - Native App to REST service - Authentication with ACS via Browser Dialog
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
- Windows Azure Access Control Service
- windows azure active directory
- windows azure authentication library
## Topics
- Authentication
- claims-based authentication
- Identity
## Updated
- 09/17/2013
## Description

<h1><span style="font-size:small"><span style="font-size:medium">Authentication via Browser Dialog - Readme</span></span></h1>
<p><span style="font-size:small">Overview</span></p>
<p><span style="font-size:small">This sample </span><span style="font-size:small">demonstrates how to use the Windows Azure Active Directory Authentication</span></p>
<p style="text-align:justify"><span style="font-size:small">Library (ADAL) package to add user authentication capabilities to a WPF client.
</span><span style="font-size:small">Furthermore, it demonstrates how to authenticate calls to a Web API REST
</span><span style="font-size:small">service by leveraging the JSON Web Token Handler for Microsoft .Net Framework
</span><span style="font-size:small">4.5 (JWT handler).</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">ADAL is a </span><span style="font-size:small">library, built on .Net 4.0, offering a simple programming model for Windows</span><br>
<span style="font-size:small">Azure Active Directory (AAD) in client applications. Its main purpose is to
</span><span style="font-size:small">help developers easily obtain access tokens from Windows Azure Active
</span><span style="font-size:small">Directory, to be used for requesting access to protected resources such as REST
</span><span style="font-size:small">services.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">The JSON Web </span><span style="font-size:small">Token Handler for Microsoft .Net Framework (JWT handler) is a library built on
</span><span style="font-size:small">.NET 4.5 which adds the JSON Web token format as a first-class citizen in the
</span><span style="font-size:small">.NET programming model. The JWT handler can be used both within the WIF
</span><span style="font-size:small">pipeline, to secure existing Web sites and services with JWT tokens in addition
</span><span style="font-size:small">to the formats supported out of the box (such as SAML1.1 and SAML2). The JWT
</span><span style="font-size:small">handler can also be used standalone, with no direct dependencies on WIF
</span><span style="font-size:small">configuration.</span></p>
<h2><span style="font-size:small">Prerequisites</span></h2>
<ul>
<li><span style="font-size:small">Visual </span><span style="font-size:small">Studio 2012.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></li><li><span style="font-size:small">A </span><span style="font-size:small">working internet connection.</span>
</li><li><span style="font-size:small"><a href="http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c">NuGet package Manager</a>.</span>
</li></ul>
<h2><span style="font-size:small">Running the Sample</span></h2>
<p><span style="font-size:small">Open the solution in Visual Studio 2012.</span></p>
<p><span style="font-size:small">The sample </span><span style="font-size:small">solution includes three projects:</span></p>
<ul>
<li><span style="font-size:small"><strong>ShipperServiceWebAPI</strong></span><br>
<br>
<span style="font-size:small">A .Net 4.5 MVC4 WebAPI&nbsp;project, implementing a simple REST fa&ccedil;ade on top</span><br>
<span style="font-size:small">of a collection of shipments. It utilizes the functionality in the JWT handler</span><br>
<span style="font-size:small">package.</span> </li><li><span style="font-size:small"><strong>ShipperClient</strong></span><br>
<br>
<span style="font-size:small">A .Net 4.0 WPF project implementing a simple client which consumes the API</span><br>
<span style="font-size:small">exposed by ShipperServiceWebAPI. ShipperClient can be used for displaying the</span><br>
<span style="font-size:small">shipments assigned to the current user and creating new ones. It utilizes the</span><br>
<span style="font-size:small">functionality in the ADAL package.</span> </li><li><span style="font-size:small"><strong>LocalSTS</strong></span><br>
<br>
<span style="font-size:small">A .Net 4.5 project implementing a test STS. The purpose of this project is to</span><br>
<span style="font-size:small">act as an Identity Provider for the ACS tenant that&rsquo;s pre-configured for the</span><br>
<span style="font-size:small">sample. It will allow you to experiment an end to end scenario without</span><br>
<span style="font-size:small">requiring you to have access to a working instance of ADFS2. You should make</span><br>
<span style="font-size:small">sure to use LocalSTS only for testing purposes.</span>
</li></ul>
<p><span style="font-size:small">The sample is </span><span style="font-size:small">configured to run the ShipperServiceWebAPI &nbsp;in IIS Express on https. In order to get the
</span><span style="font-size:small">sample working, please copy the localhost certificate with friendly name = &ldquo;IIS
</span><span style="font-size:small">Express Development Certificate&rdquo; from Local Computer -&gt; My store to Trusted
</span><span style="font-size:small">Root store, otherwise the client complains that the https certificate is
</span><span style="font-size:small">invalid.</span></p>
<ul>
<li><span style="font-size:small">To do </span><span style="font-size:small">this, run mmc.exe.&nbsp; Go to File -&gt;
</span><span style="font-size:small">Add/Remove snap-in, choose certificates and click Add. Choose &ldquo;Computer
</span><span style="font-size:small">account&rdquo;, click &ldquo;Finish&rdquo; and then click &ldquo;OK&rdquo;.
</span></li><li><span style="font-size:small">Now </span><span style="font-size:small">go to Personal -&gt; Certificates and look for &ldquo;localhost&rdquo; certificate issued</span><br>
<span style="font-size:small">by &ldquo;localhost&rdquo; and friendly name = &ldquo;IIS Express Development Certificate&rdquo;.</span><br>
<span style="font-size:small">Export this certificate without the private key and then import into &ldquo;Trusted</span><br>
<span style="font-size:small">Root Certificate Authorities&rdquo;.</span> </li></ul>
<p><span style="font-size:small">To run the </span><span style="font-size:small">sample, hit F5.</span></p>
<p><span style="font-size:small">The solution is </span><span style="font-size:small">configured to start multiple projects and will take care to put all the right</span></p>
<p><span style="font-size:small">parts in motion. The sample is already configured to connect to a
</span><span style="font-size:small">pre-provisioned ACS namespace which knows about the sample service and the
</span><span style="font-size:small">identity providers it trusts.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">In order to see </span><span style="font-size:small">the scenario in action, simply click on the &ldquo;Display your shipments&rdquo; button in
</span><span style="font-size:small">the ShipperClient UI. Given that calling the corresponding service requires
</span><span style="font-size:small">presenting a security token, the application will prompt you with a dialog
</span><span style="font-size:small">displaying the list of Identity Providers configured in ACS that are trusted by
</span><span style="font-size:small">the ShipperService. That dialog is provided by ShippingClient and populated
</span><span style="font-size:small">according to the settings recorded by the pre-provisioned namespace.</span></p>
<p><span style="font-size:small">You can </span><span style="font-size:small">authenticate using your own credentials to Google or Microsoft account, or sign&nbsp;</span><span style="font-size:small">in as one of the test users provided as part of the LocalSTS
 project. Upon </span><span style="font-size:small">successful authentication you will see shipments displayed in the form that are
</span><span style="font-size:small">returned from the Shipper Service.&nbsp;</span></p>
<p><span style="font-size:small">Now that you have </span><span style="font-size:small">a token, you will see that subsequent calls to the service will no longer&nbsp;</span><span style="font-size:small">trigger an authentication prompt, as ADAL caches the
 tokens in the in-memory </span><span style="font-size:small">cache by default.</span></p>
<p><span style="font-size:small">In order to </span><span style="font-size:small">demonstrate how to enforce authorization logic when invoking a service, the</span><br>
<span style="font-size:small">sample scenario is configured to allow the creation of new shipments only to
</span><span style="font-size:small">members of the group &ldquo;Sales&rdquo;. In our setup, that means &ldquo;adam&rdquo; from the Local
</span><span style="font-size:small">STS and any user from Windows Live ID or Google. Choose &ldquo;mary&rdquo; from Local STS
</span><span style="font-size:small">to go through the unauthorized code path.</span></p>
<p><span style="font-size:small">When you want to </span><span style="font-size:small">stop debugging, hit the Stop button in Visual Studio.</span></p>
<h2><span style="font-size:small">Details</span></h2>
<p><span style="font-size:small">Let&rsquo;s take a </span><span style="font-size:small">quick look at the structure of the solution. If you want more detailed
</span><span style="font-size:small">information, please refer to the comments in the code.</span></p>
<p><span style="font-size:small">As mentioned before, <strong>ShipperClient</strong> is a .Net 4.0 project using ADAL to display the Browser dialog
</span><span style="font-size:small">and get a JWT token from ACS and <strong>ShipperServiceWebAPI</strong> is a .Net 4.5 project
</span><span style="font-size:small">using the JWT handler to validate the JWT token received from the
</span><span style="font-size:small">ShipperClient. ADAL is provided in the &ldquo;Active Directory&nbsp;Authentication Library</span><span style="font-size:small">&rdquo; NuGet package and
<em>JWTSecurityTokenHandler </em></span><span style="font-size:small">in the &ldquo;JSON Web Token Handler for Microsoft .Net Framework 4.5&rdquo; NuGet package.
</span><span style="font-size:small">Notice the assemblies&nbsp; &quot;<strong>Microsoft.IdentityModel.Clients.ActiveDirectory</strong>&rdquo;
</span><span style="font-size:small">and &ldquo;<strong>Microsoft.IdentityModel.Clients.ActiveDirectory.WindowsForms</strong>&rdquo;
</span><span style="font-size:small">under the references node in the Solution Explorer in Visual Studio of
</span><span style="font-size:small">ShipperClient and &ldquo;<strong>System.IdentityModel.Tokens.Jwt</strong>&rdquo;
</span><span style="font-size:small">in ShipperServiceWebAPI.</span></p>
<p><span style="font-size:small">Let&rsquo;s start from </span><span style="font-size:small">the client side of the solution. Open the
<strong>ShipperClient</strong> project and look</span><span style="font-size:small">at the
</span><strong style="font-size:small">app.config</strong><span style="font-size:small">. Here you will see some values that are used later by&nbsp;</span><span style="font-size:small">ADAL:</span></p>
<ol>
<li><span style="font-size:small"><em>Tenant</em></span><br>
<span style="font-size:small">This value represents the full URL identifying the Windows Azure Access Control</span><br>
<span style="font-size:small">(ACS) namespace. This sample comes with a pre-configured test ACS namespace.</span><br>
<span style="font-size:small">You will find instructions on how to re-configure the sample to connect to your</span><br>
<span style="font-size:small">own ACS namespace later in this document.</span> </li><li><span style="font-size:small"><em>ServiceRealm<br>
</em>This is a </span><span style="font-size:small">security domain identifying the target service within the tenant.</span>
</li><li><span style="font-size:small"><em>TargetService</em></span><br>
<span style="font-size:small">This is the endpoint of the REST service that the Client is targeting. In this</span><br>
<span style="font-size:small">example it is the service offered by the ShipperServiceWebAPI project.
</span></li></ol>
<p><span style="font-size:small">Now open <strong>ShipperClient.xaml.cs</strong>.
</span><span style="font-size:small">Here you will see that we have setup some application-level members, that
</span><span style="font-size:small">include <em>AuthenticationContext</em> (a &ldquo;proxy&rdquo; for your tenant). On
</span><span style="font-size:small">initialization the <em>AuthenticationContext</em> is set to the tenant specified
</span><span style="font-size:small">in the <strong>app.config</strong>. When either Display or Create Shipments is clicked GetAuthorizationHeader()
</span><span style="font-size:small">is called to get back a string containing an access token that could be added
</span><span style="font-size:small">to the http request&rsquo;s authorization header.</span></p>
<p><span style="font-size:small">GetAuthorizationHeader() </span><span style="font-size:small">does the below :</span></p>
<ul>
<li><span style="font-size:small">Gets </span><span style="font-size:small">a list of Identity Providers (Idp) configured for the resource in the ACS</span><br>
<span style="font-size:small">namespace by calling GetProviders() method on authenticationContext.</span>
</li><li><span style="font-size:small">If </span><span style="font-size:small">there is only one Idp configured, that is passed into AcquireToken() method to</span><br>
<span style="font-size:small">get back an AuthenticationResult. </span></li><li><span style="font-size:small">If </span><span style="font-size:small">there are more than one Idps, the ShippingClient app gives the user an o</span><span style="font-size:small">pportunity to select an Idp by populating a Home Realm Discovery page with</span><br>
<span style="font-size:small">buttons representing the Idps.</span> </li><li><span style="font-size:small"><em>AcquireToken</em>() then displays the Idp&rsquo;s Sign in
</span><span style="font-size:small">page where the user signs in. </span></li><li><span style="font-size:small">Upon </span><span style="font-size:small">successful authentication, AcquireToken() returns an
<em>AuthenticationResult</em> and saves it in the in memory cache for use in </span>
<span style="font-size:small">subsequent calls. </span></li></ul>
<p><span style="font-size:small">You can see how </span><span style="font-size:small">the JWT token is utilized in the
<em>GetResponseFromService </em>method, which is called by both the Display </span>
<span style="font-size:small">and Create Shipment methods. Here the authorization header (obtained by
</span><span style="font-size:small">calling GetAuthorizationHeader() (which in turn calls
<em>CreateAuthorizationHeader</em> method on the <em>AuthenticationResult</em>) is added to the HTTP Request.</span></p>
<p><span style="font-size:small">Moving on to the </span><span style="font-size:small">service side: open the
<strong>ShipperServiceWebAPI</strong> project and examine <strong>web.config</strong>.
</span><span style="font-size:small">Here you will see two values:</span></p>
<ol>
<li><span style="font-size:small"><em>Tenant</em></span> </li></ol>
<p><span style="font-size:small">&nbsp;</span><span style="font-size:small">This has the same meaning as in the ShipperClient</span></p>
<p>&nbsp; &nbsp; &nbsp; 2. <span style="font-size:small"><em>AllowedAudience</em></span></p>
<p><span style="font-size:small">This contains the value of the service&rsquo;s Audience URI, e.g. which security
</span><span style="font-size:small">realm(s) should be present in an incoming token in order for it to be
</span><span style="font-size:small">considered intended for the current service.</span></p>
<ol>
</ol>
<p><span style="font-size:small">Now take a look at the <strong>Global.asax.cs</strong>.
</span><span style="font-size:small">The most interesting class here is&nbsp; T<em>okenValidationHandler,
</em>an </span><span style="font-size:small">implementation of DelegatingHandler.&nbsp;&nbsp;
<em>TokenValidationHandler&lsquo;s </em>purpose </span><span style="font-size:small">is<em>
</em>to process request messages before they reach the application code </span><span style="font-size:small">and enforce authentication requirements. The method
<em>TryRetrieveToken </em></span><span style="font-size:small">inspects incoming http requests to verify if the authorization header contains
</span><span style="font-size:small">an OAuth2 header with a bearer token. If a bearer token is not found, the
</span><span style="font-size:small">request is not authorized and an unauthorized status code is sent back to the
</span><span style="font-size:small">Client. If the header contains a bearer token, it is validated through the
<em>JWT handler</em>. A <em>TokenValidationParameters </em>object is </span><span style="font-size:small">created to set the expected properties, issuer, audience and signing token, on
</span><span style="font-size:small">the token. The method <em>JWT handler.ValidateToken</em> is then called to&nbsp;</span><span style="font-size:small">validate the token and, upon successful validation, a new
<em>ClaimsPrincipal </em></span><span style="font-size:small">instance is set as the Principal of the current thread and as the Current user
</span><span style="font-size:small">in HttpContext.</span></p>
<p><span style="font-size:small"><strong>ShipmentController.cs</strong> contains some claims authorization
</span><span style="font-size:small">logic, to enforce the constraints on shipment creation described earlier in
</span><span style="font-size:small">this document. The sample places that code there for simplicity and clarity,
</span><span style="font-size:small">however please note that nothing prevents you from moving that logic into the
<em>TokenValidationHandler</em> if you want to </span><span style="font-size:small">keep your controller free from any access control code.</span></p>
<p><span style="font-size:small">Configuring the </span><span style="font-size:small">Solution to Use Your Own ACS Namespace</span></p>
<p><span style="font-size:small">The sample is </span><span style="font-size:small">pre-configured to run using a test tenant,
<a href="https://humongousinsurance.accesscontrol.windows.net">https://humongousinsurance.accesscontrol.windows.net</a>. You can change this sample to use
</span><span style="font-size:small">your own ACS namespace as follows.&nbsp;</span><br>
<br>
<span style="font-size:small"><strong>Important</strong>: please do not use any </span>
<span style="font-size:small">namespace you would be using for production services as some of the required
</span><span style="font-size:small">settings might require deletion of data. </span>
</p>
<ol>
<li><span style="font-size:small"><strong>Add Identity Providers to the ACS tenant :<br>
</strong>Go to Identity </span><span style="font-size:small">Providers in your tenant and click Add under Identity Providers. You could add
</span><span style="font-size:small">available Identity Providers like Google, Yahoo and Live. To add Local STS,</span><br>
<span style="font-size:small">choose WS-Federation Identity Provider under Add a custom identity provider.
</span><span style="font-size:small">Click Next and upload the metadata from file; it can be found in the
<strong>LocalSTS </strong></span><span style="font-size:small">project under<strong> FederationMetadata\2005-07\FederationMetadata.xml</strong>.</span>
</li><li><strong style="font-size:small">Add the service as a Relying Party :&nbsp;</strong><span style="font-size:small">Go to Relying Party Applications in your tenant and choose Add under Relying</span><span style="font-size:small">Party Applications.&nbsp;Choose
 to specify settings manually. Enter <em>urn:shipperservice:interactiveauthentication
</em></span><span style="font-size:small">for the <em>Realm</em>, <a href="http://localhost:34000/Interactive">
http://localhost:34000/Interactive</a> &nbsp;for the Return URL and choose </span>
<span style="font-size:small">JWT for the token format. Choose your identity providers; allow it to create a
</span><span style="font-size:small">rule group for you.</span> </li><li><span style="font-size:small">Edit </span><span style="font-size:small">your rule group for the app. Add pass through rules for the
<strong>LocalSTS</strong> for</span><br>
<span style="font-size:small">the following claim types; role, emailaddress and name.</span>
</li><li><span style="font-size:small">Change </span><span style="font-size:small">the
<em>Tenant</em> in the <strong>app.config</strong> of the <strong>ShipperClient</strong> project
</span><span style="font-size:small">and <strong>web.config</strong> of the <strong>
ShipperServiceWebAPI</strong> project to match your </span><span style="font-size:small">own ACS namespace URL.</span>
</li></ol>
<p><span style="font-size:small">Now you can run </span><span style="font-size:small">the sample with your ACS namespace.</span></p>
<h2><span style="font-size:small">Deploying the Shipper Service to Windows Azure</span></h2>
<p><span style="font-size:small">The sample </span><span style="font-size:small">solution is designed to run from your local machine; you can explore the</span><br>
<span style="font-size:small">scenario without having a Windows Azure subscription, and in fact you can
</span><span style="font-size:small">choose to use ADAL to connect to Windows Azure Active Directory regardless of
</span><span style="font-size:small">where you will run your services.</span></p>
<p><span style="font-size:small">That said, here </span><span style="font-size:small">are detailed instructions you can follow if you want to deploy the
<strong>ShipperServiceWebAPI </strong></span><span style="font-size:small">to Windows Azure.</span></p>
<p><span style="font-size:small">The steps </span><span style="font-size:small">below assume that you are using the October 2012 release of the Windows Azure
</span><span style="font-size:small">SDK. Also note that to debug you will need to run VS in administrator mode.</span></p>
<p>&nbsp;1. <span style="font-size:small">In the Solution Explorer, right click </span>
<span style="font-size:small">on the <strong>ShipperServiceWebAPI</strong> project and choose
<em>Add Windows Azure Cloud Service Project</em>. &nbsp;This will create a new project called
<strong>ShipperServiceWebAPI.Azure</strong>.</span></p>
<ol>
</ol>
<p><span style="font-size:small">2. Make sure that multiple startup </span><span style="font-size:small">projects are still enabled. The following should be marked as startup projects</span><br>
<span style="font-size:small">now: </span></p>
<ul>
<li><span style="font-size:small">LocalSTS</span> </li><li><span style="font-size:small">ShipperClient</span> </li><li><span style="font-size:small">ShipperServiceWebAPI.Azure</span> </li></ul>
<ol>
</ol>
<p><span style="font-size:small">3. To test on the local simulation </span><span style="font-size:small">environment: open
<strong>app.config</strong> in the <strong>ShipperClient</strong> project and </span>
<span style="font-size:small">change the <em>TargetService</em> value to http://127.0.0.1:81/.</span></p>
<ol>
</ol>
<p><span style="font-size:small">4. To publish select <em>Publish</em> on </span>
<span style="font-size:small">the <strong>ShipperServiceWebAPI.Azure</strong> project. Select the Cloud Service where
</span><span style="font-size:small">you would like to deploy to and choose <em>Publish.</em></span></p>
<ol>
</ol>
<p><span style="font-size:small">5. Once published open <strong>app.config </strong>
</span><span style="font-size:small">in the <strong>ShipperClient</strong> project and change the
<em>TargetService</em> value </span><span style="font-size:small">to the URL of the published service.</span></p>
<ol>
</ol>
<p><span style="font-size:small">6. Once the deployment took place: before </span>
<span style="font-size:small">launching the debugger, change your startup projects settings so only the
</span><span style="font-size:small">following projects are enabled:</span></p>
<ul>
<li><span style="font-size:small">LocalSTS</span> </li><li><span style="font-size:small">ShipperClient</span> </li></ul>
<h2><span style="font-size:small">Security Considerations</span></h2>
<ol>
<li><span style="font-size:small">The local STS is provided as an</span><br>
<span style="font-size:small">alternative to using your own ADFS instance, it does not demonstrate any ADAL</span><br>
<span style="font-size:small">or JWT handler capabilities and should not be used as a basis for creating your</span><br>
<span style="font-size:small">own STS.</span> </li><li><span style="font-size:small">When a custom token cache is plugged</span><br>
<span style="font-size:small">into ADAL, make sure that the entries in the cache are encrypted so that they</span><br>
<span style="font-size:small">are secure. </span></li><li><span style="font-size:small">When the app receives tenant url and</span><br>
<span style="font-size:small">resource Id in 401 challenge, make sure to validate both of them. ADAL could do</span><br>
<span style="font-size:small">authority validation of AAD and ACS, but when the authority is ADFS, an out of</span><br>
<span style="font-size:small">band validation should be done. Similarly, an out of band validation should be</span><br>
<span style="font-size:small">performed on resource Id.</span> </li><li><span style="font-size:small">Note that the browser dialog that is</span><br>
<span style="font-size:small">used for the authentication flow in ADAL does not have an address bar.
</span></li><li><span style="font-size:small">The JWT Tokens issued by ACS are not</span><br>
<span style="font-size:small">encrypted and hence must be sent to the Service on a secure channel like https</span><br>
<span style="font-size:small">in order to prevent information disclosure, spoofing and other security</span><br>
<span style="font-size:small">attacks. </span></li><li><span style="font-size:small">The exceptions thrown by the JWT</span><br>
<span style="font-size:small">handler could contain sensitive information and it is up to the applications</span><br>
<span style="font-size:small">using it to make sure that this sensitive information is not sent to the</span><br>
<span style="font-size:small">Client.</span> </li><li><span style="font-size:small">JWT handler could be configured to</span><br>
<span style="font-size:small">skip audience verification and Issuer verification. The security implications</span><br>
<span style="font-size:small">of turning off these checks should be understood.</span>
</li><li><span style="font-size:small">JWT handler does not log the token but</span><br>
<span style="font-size:small">application logging the tokens should be careful about information disclosure.</span>
</li></ol>
