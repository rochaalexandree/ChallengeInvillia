<template>
  <div>
    <Nav />
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">
          <ul class="list-group">
            <li class="list-group-item active">
              GAMES
            </li>
            <li v-for="g in storagedGames" :key="g" class="list-group-item list-game-item">
              <div>
                {{ g }}
              </div>
              <select v-model="selectedValues[g]" class="form-control" style="width: 100px; margin: 8px 8px 8px auto">
                <option v-for="friend in friends" :key="friend.Name">{{friend.Name}}</option>
              </select>
              <button class="btn btn-light" @click="() => handleEmprestar(g)"> Emprestar </button>
            </li>
          </ul>
        </div>
        <div class="col-md-8">
          <div class="row">
            <div v-for="item in friends" :key="item.Name" class="col-md-4">
              <div class="card" style="margin: 0px 0 32px">
                <div class="card-body">
                  <h5 class="card-title">{{ item.Name }}</h5>
                  <p class="card-text">{{ item.Email }}</p>
                  <ul class="list-group">
                    <li class="list-group-item active">
                      GAMES
                    </li>
                    <li class="list-group-item" v-for="game in item.Games" :key="game">
                      {{ game }}
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import http from '../utils/http';
import Nav from '@/components/Nav';
import { LOGOUT } from '@/store/actions.type.js';

export default {
  name: 'Dashboard',
  components: {
    Nav,
  },
  data: function() {
    return {
      name: this.$store.state.auth.user.name,
      friends: [
        { Name: 'name 1', Age: 10, Email: 'abc@hotmail.com', Games: ['a', 'b', 'c'] },
        { Name: 'name laksdk', Age: 10, Email: 'abc@hotmail.com', Games: ['x', 'b', 'c']  },
        { Name: 'name 1231231', Age: 10, Email: 'abc@hotmail.com', Games: ['d', 'b', 'c']  },
        { Name: 'name 99', Age: 10, Email: 'abc@hotmail.com', Games: ['a', 'e', 'c']  },
        { Name: 'name 21', Age: 10, Email: 'abc@hotmail.com', Games: ['f', 'b', 'c']  },
      ],
      storagedGames: [
        'assasins creed',
        'wingin eleven',
        'um nome muito grande para caber em uma linha '
      ],
      selectedValues: {}
    }
  },
  methods: {
    logout: function() {
      this.$store
        .dispatch(LOGOUT)
        .then(() => {
          this.$router.push({ path: '/' })
        })
        .catch(() => {});
    },
    handleEmprestar: function(game) {
      if (!game || !this.selectedValues[game] ) {
        return;
      }
            console.log(game, this.selectedValues[game]);

    }
  },
  created: function() {
    http.get(`api/friends`)
    .then(function (response) {
      this.friends = response.data;
    })
    .catch(function () {
      // location.reload()
    });
  },
}
</script>


<style>
.list-game-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-direction: row;
}
</style>