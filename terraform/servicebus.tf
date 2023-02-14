resource "azurecaf_name" "servicebus_name" {
  name          = "orchestrator"
  resource_type = "azurerm_servicebus_namespace"
  suffixes      = ["sharperbox"]
  clean_input   = true
}

resource "azurerm_servicebus_namespace" "servicebus" {
  name                = azurecaf_name.servicebus_name.result
  location            = var.Location
  resource_group_name = var.ResourceGroup
  sku                 = "Standard"
}
