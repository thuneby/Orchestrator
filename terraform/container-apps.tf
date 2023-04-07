resource "azurerm_log_analytics_workspace" "example" {
  name                = "acctest-01"
  location            = azurerm_resource_group.orchestrator.location
  resource_group_name = azurerm_resource_group.orchestrator.name
  sku                 = "PerGB2018"
  retention_in_days   = 30
}


resource "azurerm_container_app_environment" "container-env" {
  name                       = "container-environment"
  resource_group_name        = azurerm_resource_group.orchestrator.name
  log_analytics_workspace_id = azurerm_log_analytics_workspace.example.id
  location                   = azurerm_resource_group.orchestrator.location
}

resource "azurerm_container_app" "testapp" {
  name                         = "test-app"
  container_app_environment_id = azurerm_container_app_environment.container-env.id
  resource_group_name          = azurerm_resource_group.orchestrator.name
  revision_mode                = "Single"

  template {
    container {
      name   = "examplecontainerapp"
      image  = "mcr.microsoft.com/azuredocs/containerapps-helloworld:latest"
      cpu    = 0.25
      memory = "0.5Gi"
    }
  }
}

