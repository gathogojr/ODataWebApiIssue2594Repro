This repo is intended to reproduce [OData WebApi Issue #2594](https://github.com/OData/WebApi/issues/2594) or alternatively provide a working solution

Demonstrates that both OData Web API 5.7.0 and 7.4.1 don't render @odata.nextLink on the last page.

## Projects Details

### ODataWebApiIssue2594Repro.V5x.InMemory
- Microsoft.AspNet.WebApi.OData 5.7.0
- Data Source: In-memory collection

### ODataWebApiIssue2594Repro.V5x.SqlServer
- Microsoft.AspNet.WebApi.OData 5.7.0
- Data Source: EntityFramework/SqlServer


### ODataWebApiIssue2594Repro.V7x.InMemory
- Microsoft.AspNetCore.OData 7.4.1
- Data Source: In-memory collection

### ODataWebApiIssue2594Repro.V7x.SqlServer
- Microsoft.AspNetCore.OData 7.4.1
- Data Source: EntityFrameworkCore/SqlServer


### ODataWebApiIssue2594Repro.Vx.InMemory
- Microsoft.AspNetCore.OData 8.0.3
- Data Source: In-memory collection