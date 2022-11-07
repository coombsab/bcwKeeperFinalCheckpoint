<template>
  <section class="vault container-fluid">
    <div class="row p-3 d-flex justify-content-center">
      <div class="col-md-5">
        <div class="vault-card text-visible p-3 d-flex flex-column align-items-center justify-content-end" :style="{ backgroundImage: `url(${vault?.img})`}">
          <h1>{{vault?.name}}</h1>
          <span>by {{vault?.creator.name}}</span>
        </div>
        <div class="w-100 d-flex justify-content-end px-3">
          <div class="dropdown open">
            <button class="btn p-0" type="button" id="vaultOptions" data-bs-toggle="dropdown" aria-haspopup="true"
                aria-expanded="false">
                <img src="../assets/img/dots.png" alt="" class="selectable">
                </button>
            <div class="dropdown-menu text-center" aria-labelledby="vaultOptions">
              <button class="dropdown-item">Edit</button>
              <button class="dropdown-item">Delete</button>
            </div>
          </div>
        </div>
        <div class="d-flex justify-content-center"><span class="keeps-count px-2 py-2">{{keeps.length}} Keeps</span></div>
      </div>
    </div>

  </section>
  <div class="keeps p-3">
    <KeepCard v-for="k in keeps" :key="k.vaultKeepId" :keep="k" />  
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState";
import KeepCard from "../components/KeepCard.vue";
import { keepsService } from "../services/KeepsService";
import { vaultsService } from "../services/VaultsService";
import Pop from "../utils/Pop";

export default {
    setup() {
      const route = useRoute();

      async function getKeepsInVault() {
        try {
          await keepsService.getKeepsInVault(route.params.vaultId)
        }
        catch(error) {
          Pop.error(error.message, "[function]")
        }
      }

      async function setActiveVault() {
        try {
          await vaultsService.setActiveVault(route.params.vaultId)
        }
        catch(error) {
          Pop.error(error.message, "[function]")
        }
      }

      onMounted(() => {
        getKeepsInVault()
        setActiveVault()
      })

        return {
            route,
            keeps: computed(() => AppState.keepsInVault),
            vault: computed(() => AppState.activeVault)
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