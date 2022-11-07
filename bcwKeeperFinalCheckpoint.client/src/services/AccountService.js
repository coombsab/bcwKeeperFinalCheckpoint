import { AppState } from '../AppState'
import { Keep } from "../models/Keep"
import { Profile } from "../models/Profile"
import { Vault } from "../models/Vault"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getProfile(profileId) {
    AppState.activeProfile = null
    const res = await api.get(`api/profiles/${profileId}`)
    AppState.activeProfile = new Profile(res.data)
  }

  async getUserVaults(profileId) {
    AppState.vaults = []
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    AppState.vaults = res.data.map(data => new Vault(data))
  }

  async getUserKeeps(profileId) {
    AppState.keeps = []
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    AppState.keeps = res.data.map(data => new Keep(data))
  }
}

export const accountService = new AccountService()
