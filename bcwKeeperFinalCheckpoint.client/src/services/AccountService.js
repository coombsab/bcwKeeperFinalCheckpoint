import { AppState } from '../AppState'
import { Profile } from "../models/Profile"
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
    const res = await api.get(`api/profile/${profileId}`)
    AppState.activeProfile = new Profile(res.data)
  }
}

export const accountService = new AccountService()
