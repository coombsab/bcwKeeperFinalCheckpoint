<template>
  <section class="vault">
    <Tag :tag="'Vault Page ' + route.params.vaultId" />
  </section>
</template>

<script>
import { useRoute } from "vue-router";

export default {
  setup() {
    const route = useRoute()
    return {
      route
    }
  }
}
</script>

<style scoped lang="scss">
  
</style>