resource "azurecaf_name" "apim_name" {
  name          = "apim-orchestrator"
  resource_type = "general"
  suffixes      = ["sharperbox"]
  clean_input   = true
}

# resource "azurerm_api_management" "apim" {
#   name                = azurecaf_name.apim_name.result
#   location            = azurerm_resource_group.orchestrator.location
#   resource_group_name = azurerm_resource_group.orchestrator.name
#   publisher_name      = "Sharperbox"
#   publisher_email     = "api@sharperbox.dk"
#   sku_name            = "Consumption_0"
# }
