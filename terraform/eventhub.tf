resource "azurecaf_name" "eventhub_namespace" {
  name          = "eventhub-orchestrator"
  resource_type = "azurerm_servicebus_namespace"
  suffixes      = ["sharperbox"]
  clean_input   = true
}

resource "azurerm_eventhub_namespace" "eventhub_namespace" {
  name                = azurecaf_name.eventhub_namespace.result
  resource_group_name = azurerm_resource_group.orchestrator.name
  location            = azurerm_resource_group.orchestrator.location
  sku                 = "Standard"
  capacity            = 1
}

resource "azurerm_eventhub" "hub" {
  name                = "events"
  namespace_name    = azurecaf_name.eventhub_namespace.result
  resource_group_name = azurerm_resource_group.orchestrator.name
  partition_count     = 2
  message_retention   = 1
}
