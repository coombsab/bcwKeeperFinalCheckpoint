<template>
  <div class="d-flex gap-2 align-items-center selectable rounded" type="button" @click="removeKeepFromVault()">
    <img src="../assets/img/remove.png" alt="Remove Keep from Vault">
    <span>Remove</span>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import Pop from "../utils/Pop";

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup(props) {
    return {
      vault: computed(() => AppState.activeVault),
      async removeKeepFromVault() {
        try {
          let modal = document.getElementById("keepDetailsModal")
          modal.style.zIndex = "0"
          const yes = await Pop.confirm(`Remove ${props.keep.name} from ${this.vault.name}?`)
          modal.style.zIndex = "2000"
          if (!yes) {
            return
          }
          Pop.toast(`Removed ${props.keep.name} from ${this.vault.name}`)
        }
        catch(error) {
          Pop.error(error.message, "[function]")
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