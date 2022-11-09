import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Profile.js').Profile} */
  activeProfile: null,
  /** @type {import('./models/KeepInVault.js').KeepInVault[]} */
  keepsInVault: [],
  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],
  activeKeep: null,
  /** @type {import('./models/Vault.js').Vault[]} */
  myVaults: [],
  /** @type {import('./models/Keep.js').Keep[]} */
  myKeeps: [],
  /** @type {import('./models/Vault.js').Vault} */
  activeVault: null,
  /** @type {import('./models/Vault.js').Vault[]} */
  vaults: []
})
