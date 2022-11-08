<template>
  <div class="d-flex gap-2 align-items-center" v-if="myVaults.length > 0">
    <select name="selectVault" id="selectVault" v-model="editable.vaultId" placeholder="Select a Vault" required>
      <option v-for="v in myVaults" :value="v.id">{{ v.name }}</option>
    </select>
    <button class="btn" type="submit" @click="saveKeepToVault()">save</button>
  </div>
  <div v-else><span>You have no vaults.</span></div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { ref } from "vue";
import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import { vaultKeepsService } from "../services/VaultKeepsService";
import Pop from "../utils/Pop";

export default {
  props: {
    keep: { type: Keep }
  },
  setup(props) {
    const editable = ref({})

    return {
      editable,
      myVaults: computed(() => AppState.myVaults),
      async saveKeepToVault() {
        try {
          await vaultKeepsService.saveKeepToVault(this.editable.vaultId, props.keep.id)
          // For closing modal, but not sure if I want this behavior
          // const modal = document.getElementById("keepDetailsModal")
          // const body = document.querySelector("body")
          // modal.style.display = "none"
          // body.style.overflow = "auto"
          Pop.toast(`Saved ${props.keep.name} to vault.`)
          editable.value = {}
        }
        catch (error) {
          Pop.error(error.message, "[saveKeepToVault]")
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">

</style>