<template>
  <div class="d-flex gap-2 align-items-center selectable rounded" type="button" @click="removeKeepFromVault()" aria-label="Remove Keep from Vault">
    <img src="../assets/img/remove.png" alt="Remove Keep from Vault">
    <span>Remove</span>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import { vaultKeepsService } from "../services/VaultKeepsService";
import Pop from "../utils/Pop";

export default {
  props: {
    keepInVault: { type: Object }
  },
  setup(props) {
    return {
      vault: computed(() => AppState.activeVault),
      async removeKeepFromVault() {
        try {
          let modal = document.getElementById("keepDetailsModal")
          modal.style.zIndex = "0"
          const yes = await Pop.confirm(`Remove ${props.keepInVault.name} from ${this.vault.name}?`)
          modal.style.zIndex = "2000"
          if (!yes) {
            return
          }

          await vaultKeepsService.removeKeepFromVault(props.keepInVault.vaultKeepId)
          modal.style.display = "none"
          let body = document.querySelector("body");
          body.style.overflow = "auto"
          Pop.toast(`Removed ${props.keepInVault.name} from ${this.vault.name}`, "warning", "top")

        }
        catch (error) {
          Pop.error(error.message, "[removeKeepFromVault]")
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
img {
  height: 18px;
  width: 18px;
}
</style>