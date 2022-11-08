<template>
  <section class="vault container-fluid">
    <div class="row p-3 d-flex justify-content-center">
      <div class="col-md-5">
        <div class="vault-card text-visible p-3 d-flex flex-column align-items-center justify-content-end"
          :style="{ backgroundImage: `url(${vault?.img})` }">
          <h1>{{ vault?.name }}</h1>
          <span>by {{ vault?.creator.name }}</span>
        </div>
        <div class="w-100 d-flex justify-content-end px-3">
          <div class="dropdown open" v-if="vault?.creatorId === account?.id">
            <button class="btn p-0" type="button" id="vaultOptions" data-bs-toggle="dropdown" aria-haspopup="true"
              aria-expanded="false">
              <img src="../assets/img/dots.png" alt="" class="selectable">
            </button>
            <div class="dropdown-menu text-center" aria-labelledby="vaultOptions">
              <button class="dropdown-item" data-bs-toggle="modal" data-bs-target="#editVaultModal">Edit</button>
              <button class="dropdown-item" @click="deleteVault()">Delete</button>
            </div>
          </div>
        </div>
        <div class="d-flex justify-content-center mt-1"><span class="keeps-count px-2 py-2">{{ keepsInVault.length }}
            Keeps</span></div>
      </div>
    </div>

  </section>
  <div class="keeps p-3">
    <KeepCard v-for="k in keepsInVault" :key="k.vaultKeepId" :keepInVault="k" />
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted, watchEffect } from "vue";
import { useRoute, useRouter } from "vue-router";
import { AppState } from "../AppState";
import KeepCard from "../components/KeepCard.vue";
import { keepsService } from "../services/KeepsService";
import { vaultsService } from "../services/VaultsService";
import Pop from "../utils/Pop";

export default {
  setup() {
    const route = useRoute();
    const router = useRouter();

    async function getKeepsInVault() {
      try {
        await keepsService.getKeepsInVault(route.params.vaultId)
      }
      catch (error) {
        Pop.error(error.message, "[getKeepsInVault]")
      }
    }

    async function setActiveVault() {
      try {
        await vaultsService.setActiveVault(route.params.vaultId)
      }
      catch (error) {
        Pop.error(error.message, "[setActiveVault]")
      }
    }

    onMounted(() => {
      getKeepsInVault()
      setActiveVault()
    })

    //Grabs info again once authenticated
    // watchEffect(() => {
    //   if (AppState.user.isAuthenticated) {
    //     getKeepsInVault()
    //     setActiveVault()
    //   }
    // })

    // watchEffect(() => {
    //   if (AppState.activeVault?.isPrivate && AppState.activeVault?.creatorId !== AppState.account?.id) {
    //     router.push({ name: 'Home' })
    //     Pop.toast("That vault is private and is not yours")
    //     AppState.activeVault = null
    //   }
    // })

    return {
      route,
      router,
      keepsInVault: computed(() => AppState.keepsInVault),
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      async deleteVault() {
        try {
          const yes = await Pop.confirm(`Do you want to delete ${this.vault.name}?`)
          if (!yes) {
            return
          }
          await vaultsService.deleteVault(route.params.vaultId)
          router.push({ name: 'Home' })
          Pop.toast(`${this.vault.name} has been deleted!`)
        }
        catch (error) {
          Pop.error(error.message, "[deleteVault]")
        }
      }
    };
  },
  components: { KeepCard }
}
</script>

<style scoped lang="scss">
.keeps {
  columns: 2;
}

.keeps-count {
  background-color: #DED6E9;
  border-radius: 15px;
}

@media screen and (min-width: 768px) {
  .keeps {
    columns: 4;
  }

  .vault-card {
    height: 20vh;
    background-position: center;
    background-size: cover;
    border-radius: 6.94872px;
  }
}
</style>