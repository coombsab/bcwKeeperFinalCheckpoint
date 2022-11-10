<template>
  <section class="account text-center h-80" v-if="account.id">
    <ProfileCard :account="account" />
    <div class="p-3" v-if="myVaults.length > 0">
      <h1>Vaults</h1>
    </div>
    <div class="mb-3" v-else>
      <h3>You have no vaults.  Please create some!</h3>
    </div>
    <section class="vaults gap-3">
    </section>
    <section class="container-fluid">
      <div class="row">
        <div class="col-6 col-md-3 p-3" v-for="v in myVaults">
          <VaultCard :key="v.id" :vault="v" />
        </div>
      </div>
    </section>
    <div class="p-3" v-if="myKeeps.length > 0">
      <h1>Keeps</h1>
    </div>
    <div v-else>
      <h3>You have no keeps.  Please create some!</h3>
    </div>
    <section class="keeps p-3">
      <KeepCard v-for="k in myKeeps" :key="k.id" :keep="k" />
    </section>
  </section>
  <div class="d-flex flex-column h-80 pos-relative" v-else>
    <span class="fadeIn m-auto fs-1 fw-700 p-3">Could not find your account.</span>
    <Spinner />
  </div>
</template>

<script>
import { computed, onMounted, watchEffect } from 'vue'
import { AppState } from '../AppState'
import KeepCard from "../components/KeepCard.vue"
import ProfileCard from "../components/ProfileCard.vue"
import VaultCard from "../components/VaultCard.vue"

export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.activeProfile),
      myVaults: computed(() => AppState.myVaults.sort(function(a, b) {
        // turnary could be used, but maybe splitting it up is easier to read?
        // return (a.isPrivate === b.isPrivate ? 0 : a.isPrivate ? 1 : -1) 

        if (a.isPrivate === b.isPrivate) {
          return 0
        } else if (a.isPrivate){
          return 1
        } else {
          return -1
        }
      })),
      myKeeps: computed(() => AppState.myKeeps)
    };
  },
  components: { KeepCard, VaultCard, ProfileCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.keeps {
  columns: 2;
}

@media screen and (min-width: 768px) {
  .keeps {
    columns: 4;
  }
}
</style>
