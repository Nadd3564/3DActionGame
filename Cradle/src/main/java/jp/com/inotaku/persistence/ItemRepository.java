package jp.com.inotaku.persistence;

import jp.com.inotaku.domain.Item;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ItemRepository extends JpaRepository<Item, Long>{

}
