# How to Create Unit Tests for New Client APIs in Binance.Net

When adding new client APIs to the Binance.Net library, it's important to create comprehensive unit tests that validate both the request structure and response handling. Here's a step-by-step guide:

## 1. Understand the Test Architecture

Binance.Net uses several test categories:
- **Unit Tests**: Testing API methods in isolation
- **Socket Tests**: Testing WebSocket functionality
- **Integration Tests**: Testing against actual Binance API

## 2. Create Test Response Data

```
1. Create a text file in the appropriate directory:
   - For REST API: `Endpoints/{API_Category}/{Functionality}/{EndpointName}.txt`
   - For WebSocket: `Subscriptions/{API_Category}/{EndpointName}.txt`

2. Format the file with:
   - HTTP method (GET/POST)
   - Endpoint path
   - Authentication requirement (true/false)
   - JSON response example
```

## 3. Add Unit Tests for REST API Methods

```csharp
[Test]
public async Task Validate{Category}Calls()
{
    var client = new BinanceRestClient(opts =>
    {
        opts.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456");
    });
    
    var tester = new RestRequestValidator<BinanceRestClient>(
        client, 
        "Endpoints/{Category}/{Functionality}", 
        "https://api.binance.com", 
        IsAuthenticated);
        
    await tester.ValidateAsync(
        client => client.{Category}Api.{Functionality}.{YourNewMethodAsync}(), 
        "{EndpointName}",
        ignoreProperties: new List<string> { "propertyToIgnore" });  // Optional
}
```

## 4. Add Unit Tests for WebSocket Methods

### For Socket Requests:

```csharp
[Test]
public async Task Validate{Category}{Functionality}Calls()
{
    var tester = new SocketRequestValidator<BinanceSocketClient>("Socket/{Category}/{Functionality}");
    
    await tester.ValidateAsync(
        CreateClient(), 
        client => client.{Category}Api.{Functionality}.{YourNewMethodAsync}(), 
        "{EndpointName}",
        responseMapper: x => x.Result,
        nestedJsonProperty: "result");
}
```

### For Socket Subscriptions:

```csharp
[Test]
public async Task Validate{Category}Subscriptions()
{
    var client = new BinanceSocketClient(opts =>
    {
        opts.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456");
    });
    
    var tester = new SocketSubscriptionValidator<BinanceSocketClient>(
        client, 
        "Subscriptions/{Category}", 
        "https://{api-url}.binance.com",
        "data");
        
    await tester.ValidateAsync<{ResponseType}>(
        (client, handler) => client.{Category}Api.{Functionality}.{YourNewSubscriptionMethodAsync}("{symbol}", handler),
        "{EndpointName}",
        ignoreProperties: new List<string> { "propertyToIgnore" });  // Optional
}
```

## 5. Add Integration Tests

```csharp
[Test]
public async Task Test{Category}{Functionality}()
{
    await RunAndCheckResult(
        client => client.{Category}Api.{Functionality}.{YourNewMethodAsync}(params),
        requiresAuth: true);  // Set to false if no auth required
}
```

## 6. Register New Model Types for Serialization

When adding new model types, you must register them in the `BinanceSourceGenerationContext.cs` file to ensure proper serialization:

```csharp
// In Binance.Net/Converters/BinanceSourceGenerationContext.cs
// Add your model type and any related types that will be used for serialization
[JsonSerializable(typeof(YourNewModelType))]
[JsonSerializable(typeof(YourNewModelType[]))]
[JsonSerializable(typeof(BinanceResponse<YourNewModelType>))]
[JsonSerializable(typeof(BinanceResponse<YourNewModelType[]>))]
```

Forgetting this step will result in serialization errors when running tests, such as:

```
DeserializeError: JsonTypeInfo metadata for type 'YourType' was not provided by TypeInfoResolver 
of type 'Binance.Net.Converters.BinanceSourceGenerationContext'
```

## 7. Test Common Edge Cases

- Missing required parameters
- Invalid parameter values
- Authentication failures
- Rate limiting
- Error response handling

## 8. Tips for Effective Testing

- Group related tests by API category and functionality
- Reuse test data when appropriate
- Use consistent naming conventions
- Test both success and failure scenarios
- Validate response deserialization works correctly
- For complex objects, verify nested property mapping

## 9. Running Tests

```powershell
# Run all tests
dotnet test

# Run specific test category
dotnet test --filter "FullyQualifiedName~BinanceClientTests"

# Run specific test
dotnet test --filter "Name=Validate{Category}Calls"
```

Following these guidelines ensures that your new API methods are thoroughly tested and maintain the quality standards of the Binance.Net library.