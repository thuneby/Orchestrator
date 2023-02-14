resource "azurerm_resource_group" "orchestrator" {
    name        = var.resource_group
    location    = var.location
}
