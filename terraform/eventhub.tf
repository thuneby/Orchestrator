resource "azurecaf_name" "eventhub_name" {
  name          = "eventhub-orchestrator"
  resource_type = "azurerm_servicebus_namespace"
  suffixes      = ["sharperbox"]
  clean_input   = true
}

resource "azurerm_eventhub_namespace" "eventhub_namespace" {
    name = azurecaf_name.eventhub_name.result
    resource_group_name = azurerm_resource_group.orchestrator.name
    location = azurerm_resource_group.orchestrator.location
    sku = "Standard"
}
