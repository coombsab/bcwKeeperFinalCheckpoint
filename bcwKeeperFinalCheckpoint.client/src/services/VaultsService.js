import { AppState } from "../AppState"
import { Vault } from "../models/Vault"
import { api } from "./AxiosService"

class VaultsService {
  async getMyVaults() {
    const res = await api.get("account/vaults")
    AppState.myVaults = res.data.map(data => new Vault(data))
  }
}

export const vaultsService = new VaultsService()