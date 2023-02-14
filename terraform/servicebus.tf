resource "azurecaf_name" "servicebus_name" {
  name          = "orchestrator"
  resource_type = "azurerm_servicebus_namespace"
  suffixes      = ["sharperbox"]
  clean_input   = true
}

resource "azurerm_servicebus_namespace" "servicebus" {
  name                = azurecaf_name.servicebus_name.result
  location            = azurerm_resource_group.orchestrator.location
  resource_group_name = azurerm_resource_group.orchestrator.name
  sku                 = "Standard"
}
