import messages from "../locale/locale";
import Config from "./config";
import Movie from "./movie";

const API_PREFIX = "api";
const API_VERSION = "v1";
const API_BASE_URL = API_PREFIX + "/" + API_VERSION;

const service = {
    movies: {
        allMovies
    },
    championship: {
        createChampionship
    },
    configs: {
        allConfigs
    }
}

async function allConfigs(): Promise<Config> {
    const response = await fetch(API_BASE_URL + "/configs");
    if (response.status === 200) {
        return await response.json() as Config;
    }
    return Promise.reject(messages.format('Status code {0} not expected', response.status));
}

async function allMovies(): Promise<Movie[]> {
    const response = await fetch(API_BASE_URL + "/movies");
    if (response.status === 200) {
        return await response.json() as Movie[];
    }
    return Promise.reject(messages.format('Status code {0} not expected', response.status));
}

async function createChampionship(ids: string[]): Promise<Movie[]> {
    const response = await fetch(API_BASE_URL + "/championships", {
        method: "POST",
        headers: new Headers({ 'Content-type': 'application/json' }),
        body: JSON.stringify(ids)
    });
    if (response.status === 200) {
        return await response.json() as Movie[];
    }
    return Promise.reject(messages.format('Status code {0} not expected', response.status));
}

export default service;