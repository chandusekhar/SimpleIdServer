import { createAction, props } from '@ngrx/store';
import { SearchResult } from '../../applications/models/search.model';
import { OAuthScope } from '../models/oauthscope.model';

export const startSearch = createAction('[OAuthScopes] START_SEARCH_SCOPES', props<{ order: string, direction: string, count: number, startIndex: number }>());
export const completeSearch = createAction('[OAuthScopes] COMPLETE_SEARCH_SCOPES', props<{ content: SearchResult<OAuthScope> }>());
export const errorSearch = createAction('[OAuthScopes] ERROR_SEARCH_SCOPES');
export const startGetAll = createAction('[OAuthScopes] START_GET_ALL_SCOPES');
export const completeGetAll = createAction('[OAuthScopes] COMPLETE_GET_ALL_SCOPES', props<{ content: OAuthScope[] }>());
export const errorGetAll = createAction('[OAuthScopes] ERROR_GET_ALL_SCOPES');
export const startGet = createAction('[OAuthScopes] START_GET_SCOPE', props<{ name: string }>());
export const completeGet = createAction('[OAuthScopes] COMPLETE_GET_SCOPE', props<{ content: OAuthScope }>());
export const errorGet = createAction('[OAuthScopes] ERROR_GET_SCOPE');
export const startUpdate = createAction('[OAuthScopes] START_UPDATE_SCOPE', props<{ name: string, claims: string[] }>());
export const completeUpdate = createAction('[OAuthScopes] COMPLETE_UPDATE_SCOPE');
export const errorUpdate = createAction('[OAuthScopes] ERROR_UPDATE_SCOPE');
export const startAdd = createAction('[OAuthScopes] START_ADD_SCOPE', props<{ name: string }>());
export const completeAdd = createAction('[OAuthScopes] COMPLETE_ADD_SCOPE', props < { name: string }>());
export const errorAdd = createAction('[OAuthScopes] ERROR_ADD_SCOPE');